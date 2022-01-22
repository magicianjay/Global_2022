using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_Weapon : BASE_Weapon
{
    [SerializeField] protected float pr_damage = 100f;
    [SerializeField] protected float pr_fireRate = 100f;

    public float WEAPON_DAMAGE => pr_damage;
    public float WEAPON_FIRERATE => pr_fireRate;
   
    public void Initialize()
    {
        _typeOwner = TypeOwner.Enemy;
    }
}
