using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Body : MonoBehaviour
{
    [SerializeField] protected float pr_vitality = 100;
    private float p_vitalityBase;
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
    
    [SerializeField] protected float pr_stamina = 100;
    private float p_staminaBase;

    public void Initialize()
    {
        p_vitalityBase = pr_vitality ;
        p_vitalityBase = pr_stamina;
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
        else
        {
            DEATHZONE.Instance.MoveObjectToDeathZone(gameObject);
            
        }
    }

    private void OnDisable()
    {
        GetComponent<ENEMY_Target>().TargetDestroy();
    }

    public virtual void CollisionWithAttack(GameObject ownerAttack,BASE_Weapon baseWeapon, float attackDamage)
    {
        Debug.Log("PLAYER : I AM ATTACKED");
     
        if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Enemy)
        {
            ENEMY_Weapon enemyWeapon = baseWeapon.GetComponent<ENEMY_Weapon>();
            pr_vitality -= enemyWeapon.WEAPON_DAMAGE;
            Debug.Log("UN ENNEMI M'ATTAQUE : "+enemyWeapon.WEAPON_DAMAGE);
        }
        else if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Player)
        {
            Debug.Log("UN PLAYER M'ATTAQUE");
        }
    }
    
}
