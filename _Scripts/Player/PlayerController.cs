using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : CoreLoad
{
    [Header("All gameobject Hull")]
    public List<GameObject> Hulls;
    [Header("All gameobject Gun")]
    public List<GameObject> Guns;
    [Header("Gameobject Upper of Player -Transform")]
    public Transform upper;
    [Header("Gameobject Lower of Player -Transform")]
    public Transform lower;
    [Header("Script PlayerMovement")]
    public PlayerMovement movement;
    [Header("Script PlayerAttack")]
    public PlayerAttack attack;
    [Header("Script PlayerHandle")]
    public PlayerHandle handle;
    [Header("Component Animator of Track")]
    public Animator aniTrackLeft, aniTrackRight;
    [Header("Component Rigidbody")]
    public Rigidbody2D _myBody;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Reset()
    {
        base.Reset();
    }
    protected override void Load()
    {
        base.Load();
    }
    protected override void LoadObject()
    {
        this.LoadAllGunHull();
    }
    protected override void LoadComponent()
    {
        //Load Component Can Thiet
        this._myBody = GetComponent<Rigidbody2D>();
        if (this.aniTrackLeft == null)
            this.aniTrackLeft = transform.Find("Model").Find("Lower").Find("Track").Find("Left").GetComponent<Animator>();
        if (this.aniTrackRight == null)
            this.aniTrackRight = transform.Find("Model").Find("Lower").Find("Track").Find("Right").GetComponent<Animator>();
        if (this.movement == null)
            this.movement = transform.Find("Movement").GetComponent<PlayerMovement>();
        if (this.attack == null)
            this.attack = transform.Find("Attack").GetComponent<PlayerAttack>();
        if (this.handle == null)
            this.handle = transform.Find("Handle").GetComponent<PlayerHandle>();
    }
    private void LoadAllGunHull()
    {
        //if (this.Hulls != null || this.Guns != null) return;
        Transform[] allChild = transform.Find("Model").gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChild)
        {
            if (child.gameObject.CompareTag("Hull"))
            {
                // get all gameobject with Tag Hull
                this.Hulls.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
            else if (child.gameObject.CompareTag("Gun"))
            {
                // get all gameobject with Tag Gun
                this.Guns.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
            else if (child.gameObject.name == "Upper")
            {
                //get gameobject Upper
                this.upper = child;
            }
            else if (child.gameObject.name == "Lower")
            {
                //get gameobject Lower
                this.lower = child;
            }
        }
    }
}
