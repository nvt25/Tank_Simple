using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public GameObject efBom;
    public int damage;
    public LayerMask layerPlayer;
    private void OnDestroy()
    {
        GameObject efBom = Instantiate(this.efBom, transform.position, Quaternion.identity);
        Destroy(efBom, 0.3f);
    }
    private void SetLethal(int damage)
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, 1, this.layerPlayer);
        if(player!= null)
        {
            // gay sat thuong
        }
    }
}
