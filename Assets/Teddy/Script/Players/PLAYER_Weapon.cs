using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PLAYER_Weapon : MonoBehaviour
{
    [SerializeField] protected float pr_damage = 100f;
    [SerializeField] protected float pr_armorPiercePercentage = 0.05f;
    [SerializeField] protected float pr_fireRate = 100f;
    [SerializeField] protected float pr_cooldownSecondaryAttack = 3f;
    [SerializeField] protected float pr_ultimeLoadPerKill = 5f;
    
     private float p_damageBase = 100f;
     private float p_armorPiercePercentageBase = 0.05f;
     private float p_fireRateBase = 100f;
     private float p_cooldownSecondaryAttackBase = 3f;
     private float p_ultimeLoadPerKillBase = 5f;

     public PLAYER_Weapon()
     {
         p_damageBase = pr_damage;
         p_armorPiercePercentageBase = pr_armorPiercePercentage;
         p_fireRateBase = pr_fireRate;
         p_cooldownSecondaryAttackBase = pr_cooldownSecondaryAttack;
         p_ultimeLoadPerKillBase = pr_ultimeLoadPerKill;
     }
     
    public abstract void WEAPON_PrimaryAttack();

    public abstract void WEAPON_SecondaryAttack();

    public abstract void WEAPON_UltimeAttack();
}
