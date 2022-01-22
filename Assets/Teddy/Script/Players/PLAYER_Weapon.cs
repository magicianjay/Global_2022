using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PLAYER_Weapon : BASE_Weapon
{
    [Header("PLAYER PARAMETERS")]
    [SerializeField] protected float pr_ultimeLoadPerKill = 5f;

    public float WEAPON_DAMAGE => pr_damage;
    public float WEAPON_FIRERATE => pr_fireRate;
   
    public float WEAPON_ULTIMELOADPERKILL => pr_ultimeLoadPerKill;
    
     private float p_damageBase = 100f;
     private float p_fireRateBase = 100f;
     
     private float p_ultimeLoadPerKillBase = 5f;

     protected PLAYER_Base p_playerBase;
     
     protected bool p_needReload = false;
     public virtual void Initialize(PLAYER_Base playerBase)
     {
         p_playerBase = playerBase;
         _typeOwner = TypeOwner.Player;
         p_damageBase = pr_damage;
         p_fireRateBase = pr_fireRate;
         p_ultimeLoadPerKillBase = pr_ultimeLoadPerKill;
     }
     
    public abstract void WEAPON_PrimaryAttack();

    protected virtual IEnumerator ReloadPrimaryAttack()
    {
        p_needReload = true;
        float timeLeft = 0;

        float fireRateCalcul = 1 / pr_fireRate ;
        
        while (timeLeft<fireRateCalcul)
        {
            timeLeft += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        p_needReload = false;
    }
    
    public abstract void WEAPON_SecondaryAttack();

    protected virtual IEnumerator ReloadSecondaryAttack()
    {
        yield return new WaitForSeconds(0);
    }
    
    public abstract void WEAPON_UltimeAttack();
}
