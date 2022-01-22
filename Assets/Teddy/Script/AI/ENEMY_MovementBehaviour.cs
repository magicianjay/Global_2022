using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ENEMY_MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float pr_speed;
    protected bool p_startMove = false;
    public virtual void Initialize()
    {
        p_startMove = true;
    }

    public abstract void MOVEMENT_Move();
}
