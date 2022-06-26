using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Script Player Controller")]
    public PlayerController playerCtl;
    [Header("Position Shoot Gun")]
    public List<Transform> firePoints;
    [Header("Force Shoot of gun")]
    public float forceShoot;
    [Header("idModel type bullet use")]
    private int idModel;
    [Header("radius player can shoot")]
    public float radiusShoot;
    [Header("layer targer scan")]
    public LayerMask enemyLayer;
    public LayerMask fenceLayer;
    [Header("Target need attack")]
    public Transform target;
    public float time;
    public float timeDelay;
    public GameObject bullet;
    public GameObject efShoot;

    private void Awake()
    {
        this.playerCtl = transform.parent.GetComponent<PlayerController>();
    }
    private void Start()
    {
        this.idModel = GameManager.instance.Sttsp;
        this.GetAllFirePoint();
    }
    private void Update()
    {
        this.AttackEnemy();
        this.ValidTarget();

    }
    private void FixedUpdate()
    {
        this.TurnGunDirectionEnemy();
    }
    private void GetAllFirePoint() // Get All Location can Shoot 
    {
        Transform[] childs = this.playerCtl.Guns[this.idModel].GetComponentsInChildren<Transform>();
        foreach (Transform child in childs)
        {
            if (child.gameObject.CompareTag("PosShoot"))
            {
                this.firePoints.Add(child);
            }
        }
    }
    private void ValidTarget()
    {
        // kiem tra xem enemy hien tai co hop le hay k
        // co target hay k
        // cotrong khoarng cach 
        // co vat can
        if (!this.target
            || Vector3.Distance(transform.position, this.target.position) > this.radiusShoot
            || Physics2D.Linecast(transform.position, this.target.transform.position, this.fenceLayer))
        {
            // 
            SelectTarget();
        }
        else
        {
            Debug.DrawLine(transform.position, this.target.position);
        }
    }
    /// <summary>
    /// Function Select target valid
    /// </summary>
    private void SelectTarget()
    {
        //tim tat ca enemy xung quang player
        Collider2D[] all = Physics2D.OverlapCircleAll(transform.position, this.radiusShoot, this.enemyLayer);
        if (all.Length > 0)
        {
            foreach (Collider2D target in all)
            {
                // neu o giua co vat can thi bo qua
                if (!Physics2D.Linecast(transform.position, target.transform.position, this.fenceLayer))
                {
                    this.target = target.transform;
                    return;
                }
            }
        }
        this.target = null;

        //Debug.Log(this.target.parent.gameObject.name);
    }
    private void AttackEnemy()
    {
        if (this.target && this.time <= 0)
        {
            this.time = this.timeDelay;
            foreach (Transform point in this.firePoints)
            {
                GameObject bullet = Instantiate(this.bullet, point.position, point.rotation);
                Rigidbody2D _body = bullet.GetComponent<Rigidbody2D>();
                _body.AddForce(point.up * this.forceShoot, ForceMode2D.Impulse);
                Destroy(bullet, 2f);
                this.EfShoot(point);
            }

        }
        else
        {
            if (this.time > 0) this.time -= Time.deltaTime;
        }
    }
    private void EfShoot(Transform firePoint)
    {
        GameObject efShoot = Instantiate(this.efShoot, firePoint.position, firePoint.rotation);
        Destroy(efShoot, 0.3f);
    }
    private void TurnGunDirectionEnemy()
    {
        if (this.target)
        {
            Vector3 lookDir = this.target.position - this.playerCtl.upper.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            this.playerCtl.upper.localRotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            this.playerCtl.upper.localRotation = Quaternion.Euler(0, 0, this.playerCtl.lower.localRotation.eulerAngles.z - 360);
        }
    }
    //percent = phan tram
    public void SetSpeedUp(float percent)
    {
        this.timeDelay -= (this.timeDelay / 2) * (percent / 100);
    }
}
