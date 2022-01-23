using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ENEMY_TargetBehaviour : MonoBehaviour
{
    [SerializeField]protected ENEMY_Target pr_tTarget;

    public ENEMY_Target TARGET => pr_tTarget;
    
    public virtual void Initialize()
    {
        ENEMY_FOUNDTARGET();
    }
    protected abstract void ENEMY_FOUNDTARGET();
    
    protected abstract void ENEMY_UPDATETARGET();

    protected virtual void TARGET_Destroyed()
    {
        ENEMY_UPDATETARGET();
    }
}
