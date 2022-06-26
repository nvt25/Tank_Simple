using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public GameObject efBom;
    public List<GameObject> bulletModels;
    private void Awake()
    {
        this.GetModelBullet();
    }
    private void GetModelBullet()
    {
        Transform[] allChild = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform child in allChild)
        {
            this.bulletModels.Add(child.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HpEnemy hp = collision.GetComponent<HpEnemy>();
            hp.SetHealth(4);
        }
        EfBom(collision.transform);
        Destroy(gameObject);
    }
    private void EfBom(Transform point)
    {
        GameObject efBom1 = Instantiate(this.efBom,transform.position,Quaternion.identity);
        Destroy(efBom1, 0.3f);
    }
}
