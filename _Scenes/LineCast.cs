using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCast : MonoBehaviour
{
    public Transform target;
    public LayerMask layerMask;
    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, this.target.position, this.layerMask);
        if (hit)
        {
            Debug.Log(hit.collider.name);
            Debug.DrawLine(transform.position, this.target.position);
        }
    }
}
