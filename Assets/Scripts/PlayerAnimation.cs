using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    public string[] idleDirection = { "IdleSouth", "IdleEast", "IdleNorth", "IdleWest" };
    public string[] runningDirection = { "RunSouth", "RunEast", "RunNorth", "RunWest" };
    string[] directionType;
    public int lastDirection;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        directionType = null;
        lastDirection = 0;
    }

    public void SetDirection(Vector2 movement)
    {
        if (movement.sqrMagnitude < 0.01)
            directionType = idleDirection;
        else
        {
            directionType = runningDirection;
            lastDirection = GetIndexByAngle(movement);
        }
        anim.Play(directionType[lastDirection]);
    }

    private int GetIndexByAngle(Vector2 movement)
    {
        Vector2 normalized = movement.normalized;
        float angle = Vector2.SignedAngle(Vector2.up, normalized);
        if (angle == -90.0f)
            return 1;
        else if (angle == 0.0f)
            return 2;
        else if (angle == 90.0f)
            return 3;

        return 0;




    }
}
