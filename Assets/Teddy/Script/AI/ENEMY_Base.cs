using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_Base : MonoBehaviour
{
    public delegate void ENEMY_Killed();
    public static event ENEMY_Killed OnEnemyKilled;
    
    
    [SerializeField]private ENEMY_Weapon _myEnemyWeapon;
    public ENEMY_Weapon ENEMY_WEAPON => _myEnemyWeapon;
    
    [SerializeField] protected float pr_vitality = 100;

    [SerializeField] protected ENEMY_MovementBehavior pr_movementBehaviour;
    [SerializeField] protected ENEMY_TargetBehaviour pr_targetBehaviour;

    public ENEMY_MovementBehavior MOVEMENTBEHAVIOUR =>pr_movementBehaviour;
    public ENEMY_TargetBehaviour TARGETBEHAVIOUR =>pr_targetBehaviour;
    
    public float VITALITY
    {
        get
        {
            return pr_vitality;
        }
        set
        {
            pr_vitality = value;
            VerifiyHP();
        }
    }
    private float p_vitalityBase;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        p_vitalityBase = pr_vitality;
        _myEnemyWeapon.Initialize(this);
        TARGETBEHAVIOUR.Initialize();
        MOVEMENTBEHAVIOUR.Initialize(this);
    }

    private void VerifiyHP()
    {
        if (pr_vitality <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        if (transform.parent != null) { Destroy(transform.parent.gameObject);}
        else { Destroy(gameObject); }
    }
    
    public virtual void CollisionWithAttack(GameObject ownerAttack,BASE_Weapon baseWeapon, float attackDamage)
    {
        Debug.Log("ENEMY : I AM ATTACKED");
        Debug.Log(baseWeapon._typeOwner);
        
        if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Player)
        {
            PLAYER_Weapon  playerWeapon = baseWeapon.GetComponent<PLAYER_Weapon>();
            VITALITY -= attackDamage;
            Debug.Log("UN PLAYER M'ATTAQUE : "+playerWeapon.WEAPON_DAMAGE);
        }
    }
    
}
