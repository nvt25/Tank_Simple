using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Use package Joystick")]
    public Joystick joystick;
    private float moveSpeed = 4;
    private Vector2 movement;
    private Vector2 valueDirectionInitial;
    private bool isRun;
    private PlayerController playerCtl;
    private void Awake()
    {
        this.playerCtl = transform.parent.GetComponent<PlayerController>();
        // value tam joystick
        valueDirectionInitial = joystick.Direction;
    }
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        if (joystick.Direction != Vector2.zero)
        {
            this.isRun = true;
        }
        else
        {
            this.isRun = false;
        }

    }
    private void FixedUpdate()
    {
        if (isRun)
        {
            this.MovePlayer();
            this.TurnAnimationTrack(this.moveSpeed);
        }
        else
        {
            this.TurnAnimationTrack(0);
        }
    }
    private void MovePlayer()
    {
        // di chuyen theo huong
        this.playerCtl._myBody.MovePosition(this.playerCtl._myBody.position + joystick.Direction * Time.deltaTime * this.moveSpeed);
        //quay
        Vector3 lookDir = joystick.Direction - this.valueDirectionInitial;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        this.playerCtl.lower.localRotation = Quaternion.Euler(0, 0, angle);
    }
    private void TurnAnimationTrack(float speed)
    {
        //animation of track when move
        this.playerCtl.aniTrackLeft.SetFloat("Run", speed);
        this.playerCtl.aniTrackRight.SetFloat("Run", speed);
    }
}
