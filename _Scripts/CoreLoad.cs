using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreLoad : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.Load();
    }
    protected virtual void Reset()
    {
        this.Load();
    }
    protected virtual void Load()
    {
        this.LoadObject();
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        //Component
    }
    protected virtual void LoadObject()
    {
        //Object
    }
}
