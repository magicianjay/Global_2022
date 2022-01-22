using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_Base : MonoBehaviour
{
    [SerializeField]private ENEMY_Weapon _myEnemyWeapon;
    public ENEMY_Weapon ENEMY_WEAPON => _myEnemyWeapon;
    
    [SerializeField] protected float pr_vitality = 100;
    private float p_vitalityBase;

    private void Awake()
    {
        Initialize();
        _myEnemyWeapon.Initialize();
    }

    public void Initialize()
    {
        p_vitalityBase = pr_vitality;
    }
    
    public virtual void CollisionWithAttack(GameObject ownerAttack,BASE_Weapon baseWeapon)
    {
        Debug.Log("ENEMY : I AM ATTACKED");
        Debug.Log(baseWeapon._typeOwner);
        
        if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Player)
        {
            PLAYER_Weapon  playerWeapon = baseWeapon.GetComponent<PLAYER_Weapon>();
            pr_vitality -= playerWeapon.WEAPON_DAMAGE;
            Debug.Log("UN PLAYER M'ATTAQUE");
        }
    }
    
}
