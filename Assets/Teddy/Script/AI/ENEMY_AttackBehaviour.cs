using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ENEMY_AttackBehaviour : MonoBehaviour
{
    [SerializeField] protected float pr_rangeWithTargetToAttack;

    private bool p_startAttack = false;

    public virtual void Initialize()
    {
        p_startAttack = true;
    }
    
}
