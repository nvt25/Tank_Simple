using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressCtl : CoreLoad
{
    public Transform player;
    public Transform posShoot;
    public GameObject fortressAttack;
    private void Start()
    {
        this.Load();
    }
    protected override void Reset()
    {
        this.Load();
    }
    protected override void Load()
    {
        if(this.player == null)
        {
            this.player = GameObject.Find("Player").transform;
        }
        if (this.posShoot == null)
            this.posShoot = transform.Find("PosShoot").transform;
        if (this.fortressAttack == null)
            this.fortressAttack = transform.Find("FortressAttack").gameObject;
    }
    
}
