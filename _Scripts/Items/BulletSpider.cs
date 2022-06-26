using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpider : MonoBehaviour
{
    public GameObject eFBom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EfBom(collision.transform);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHandle play = collision.GetComponent<PlayerHandle>();
            play.Chiu(20);
        }
    }
    private void EfBom(Transform point)
    {
        GameObject efBom1 = Instantiate(this.eFBom,transform.position,Quaternion.identity);
        Destroy(efBom1, 0.3f);
    }
}
