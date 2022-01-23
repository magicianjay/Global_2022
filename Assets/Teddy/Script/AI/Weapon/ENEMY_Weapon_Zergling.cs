using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_Weapon_Zergling : ENEMY_Weapon
{
    [SerializeField] protected GameObject p_slash;
    [SerializeField] protected float p_slashDuration;

  

    public override void WEAPON_PrimaryAttack()
    {
        if (!p_needReload)
            {
                //        Debug.Log("PRIMARY ATTACK DREAM");
                Vector3 position = transform.position + transform.right;
                Quaternion rotation = transform.rotation;
        
                GameObject newSlash = Instantiate(p_slash, position, rotation,transform);
                ATTACK_Slash attackBase = newSlash.GetComponent<ATTACK_Slash>();
                attackBase.BASEWEAPONOWNER = this ;
            
                attackBase.Initialize(gameObject,p_slashDuration, pr_damage);
                StartCoroutine(ReloadPrimaryAttack());
            }
    }
    
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
    
    
}
