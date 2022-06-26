using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressAttack1 : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 lookDir;
    public FortressCtl fortressCtl;
    float a = 0;
    private void Start()
    {
        this.fortressCtl = transform.parent.GetComponent<FortressCtl>();
    }
    private void Update()
    {
        this.lookDir = this.fortressCtl.player.position - transform.position;

        if (a <= 0)
        {
            a = 0.8f;
        AttackPlayer();
        }
        else
        {
            a -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(this.lookDir.y, this.lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.parent.localRotation = Quaternion.Euler(0, 0, angle);
    }
    private void AttackPlayer()
    {
        GameObject bullet1 = Instantiate(this.bullet, this.fortressCtl.posShoot.position, this.fortressCtl.posShoot.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(this.fortressCtl.posShoot.up * 0.005f, ForceMode2D.Impulse);
        Destroy(bullet1, 2f);
    }
}
