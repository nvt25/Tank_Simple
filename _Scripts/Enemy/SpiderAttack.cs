using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    public float distance;
    public LayerMask enemylayer;
    public Transform targetAttack;
    public Vector3 lookDri;
    public GameObject bullet;
    public GameObject efShoot;
    public Transform firePoint;
    public float forceShoot;
    public float timeDelay;
    public float time;
    private void Update()
    {
        this.GetTargetAttack();
        this.AttackTarget();
    }
    private void FixedUpdate()
    {

        if (this.targetAttack == null)
        {
            //his.playerController.upper.localRotation = Quaternion.Euler(0, 0, 0);
            return;
        }
        lookDri = targetAttack.position - transform.position;
        float angle = Mathf.Atan2(lookDri.y, lookDri.x) * Mathf.Rad2Deg - 90f;
        //this.playerController.upper.localRotation = Quaternion.Euler(0, 0, angle);
    }
    private void GetTargetAttack()
    {
        //Gim muc tieu dau tien khi gap phai
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, this.distance, this.enemylayer);
        if (enemy != null) this.targetAttack = enemy.transform;
    }
    private void AttackTarget()
    {
        if (time <= 0 && lookDri.magnitude < 3.5f)
        {
            time = timeDelay;
            GameObject bullet1 = Instantiate(bullet, this.firePoint.position, this.firePoint.rotation);
            Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * forceShoot, ForceMode2D.Impulse);
            Destroy(bullet1, 2f);
            EfShoot(firePoint);
        }
        else
        {
            if (this.time > 0)
            {
                time -= Time.deltaTime;
            }

        }
    }
    private void EfShoot(Transform firePoint)
    {
        GameObject efShoot1 = Instantiate(this.efShoot, firePoint.position, firePoint.rotation);
        Destroy(efShoot1, 0.3f);
    }
}


