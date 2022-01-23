using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Body : MonoBehaviour
{
    private PLAYER_Base _playerBase;
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

    public void Initialize(PLAYER_Base playerBase)
    {
        _playerBase = playerBase;
        UI_IG.Instance.InitializePlayer(_playerBase._idxPlayer,(int)VITALITY);
    }
    
    private void VerifiyHP()
    {
        if (VITALITY <= 0)
        {
            Death();
        }
        else
        {
//            Debug.Log(VITALITY);
            UI_IG.Instance.SetPlayerUI(_playerBase._idxPlayer,(int)VITALITY);
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
//        Debug.Log("PLAYER : I AM ATTACKED");
     
        if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Enemy)
        {
            ENEMY_Weapon enemyWeapon = baseWeapon.GetComponent<ENEMY_Weapon>();
            VITALITY -= enemyWeapon.WEAPON_DAMAGE;
//            Debug.Log("UN ENNEMI M'ATTAQUE : "+enemyWeapon.WEAPON_DAMAGE);
        }
        else if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Player)
        {
           // Debug.Log("UN PLAYER M'ATTAQUE");
        }
    }
    
}
