using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ENEMY_Weapon : BASE_Weapon
{
    [SerializeField] protected float pr_rangeAttack;
    protected ENEMY_Base pr_enemyBase;
    protected bool p_needReload;

    private void Update()
    {
        WEAPON_LookAt();
        float distance = WEAPON_CalculateDistanceBetweenTargetAndAI();

        if (pr_rangeAttack > distance)
        {
            WEAPON_PrimaryAttack();
        }
    }

    public virtual void Initialize(ENEMY_Base enemyBase)
    {
        _typeOwner = TypeOwner.Enemy;
        pr_enemyBase = enemyBase;
    }
    
    public abstract void WEAPON_PrimaryAttack();

    public virtual void WEAPON_LookAt()
    {
        Transform target = pr_enemyBase.TARGETBEHAVIOUR.TARGET.transform;
        
        Quaternion rotation = Quaternion.LookRotation
            (target.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
    
    protected float WEAPON_CalculateDistanceBetweenTargetAndAI()
    {
        Vector2 posTarget = pr_enemyBase.TARGETBEHAVIOUR.TARGET.transform.position;
        Vector2 posAI = transform.position;

        Vector2 distance = posTarget - posAI;
        float distanceMagnitude = distance.magnitude;
        return distanceMagnitude;
    }
}
