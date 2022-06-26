using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : MonoBehaviour
{
    public List<Transform> firePoints;
    public GameObject bulletPhantom;
    public bool isAtack;
    public bool gan;
    private Animator ani;
    public float time = 0;
    public float delayTime = 15;
    public int hpEnemyMax;
    public HpEnemy hpEnemy;
    private void Awake()
    {
        
        this.ani = GetComponent<Animator>();
        Transform[] all = transform.GetComponentsInChildren<Transform>();
        foreach (Transform point in all)
        {
            if (point.gameObject.CompareTag("PosShoot"))
            {
                // get all gameobject with Tag PosShoot
                this.firePoints.Add(point);
            }
        }
    }
    private void Start()
    {
        this.hpEnemy.SetHealthStart(hpEnemyMax);
    }
    private void Update()
    {
        if (gan)
        {

            if (time <= 0)
            {
                time = delayTime;

                this.isAtack = true;
            }
            else
            {

                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
            }
        }
        ani.SetBool("Attack", this.isAtack);

    }
    public void Shoot()
    {
        foreach (Transform point in this.firePoints)
        {
            this.isAtack = false;

            GameObject phantom = Instantiate(this.bulletPhantom, point);


        }

    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
