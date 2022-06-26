using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public Transform posSpawn;
    public GameObject spiderTank;
    float time = 0;
    float delayTime = 6f;
    public HpEnemy hpEnemy;
    public int hpEnemyMax;
    private void Start()
    {
        this.hpEnemy.SetHealthStart(hpEnemyMax);

    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        if(this.time <= 0)
        {
            this.time = this.delayTime;
            GameObject spider = Instantiate(this.spiderTank, this.posSpawn.position, Quaternion.identity);
        }
        else
        {
            if(this.time > 0)
            {
                this.time -= Time.deltaTime;
            }
        }
    }
}
