using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ENEMY_MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float pr_speed;
    protected bool p_startMove = false;
    protected ENEMY_Base p_enemyBase;
    
    public virtual void Initialize(ENEMY_Base enemyBase)
    {
        p_startMove = true;
        p_enemyBase = enemyBase;
    }

    public abstract void MOVEMENT_Move();
}
