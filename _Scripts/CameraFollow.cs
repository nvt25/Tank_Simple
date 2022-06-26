using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 location;
    private void LateUpdate()
    {
        this.location.x = this.player.position.x;
        this.location.y = this.player.position.y;
        this.location.z = -10;
        transform.position = this.location;
    }
}
