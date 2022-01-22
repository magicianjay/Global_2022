using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Weapon_Nighmare : PLAYER_Weapon
{
    [Header("PROJECTILE PRIMARY ATTACK NIGHTMAARE")]
    [SerializeField] private GameObject p_projectile;
    [SerializeField] private float p_projectileDuration = 0.5f;
    [SerializeField] private float p_projectileSpeed= 5f;

    [Header("SECONDARY ATTACK NIGHTMARE")] 
    [SerializeField] protected GameObject pr_secondaryAttack_PrefabAOE;
    [SerializeField] protected float pr_secondaryAttack_Cooldown = 3f;
    private float p_secondaryAttack_cooldownBase = 3f;
    
    [SerializeField] protected float pr_secondaryAttack_maxLoadingTime = 3f;

    [SerializeField] private float p_secondaryAttack_RadiusAttack = 5;
    [SerializeField] private float p_secondaryAttack_AttackDamage = 5;
    [SerializeField] private float p_secondaryAttack_AOEDuration = 5;

    public override void Initialize(PLAYER_Base playerBase)
    {
        base.Initialize(playerBase);
        p_secondaryAttack_cooldownBase = pr_secondaryAttack_Cooldown;
    }

    public override void WEAPON_PrimaryAttack()
    {
        if (!p_needReload)
        {
//        Debug.Log("PRIMARY ATTACK NIGHTMARE");

            Vector3 position = transform.position + transform.right;
            Quaternion rotation = transform.rotation;

            GameObject newSlash = Instantiate(p_projectile, position, rotation);
            ATTACK_ProjectileNightmare attackBase = newSlash.GetComponent<ATTACK_ProjectileNightmare>();
            attackBase.BASEWEAPONOWNER = this ;
            
            attackBase.Initialize(gameObject, p_projectileDuration,pr_damage, p_projectileSpeed, 5);
            StartCoroutine(ReloadPrimaryAttack());
        }
    }

    public override void WEAPON_SecondaryAttack()
    {
        Debug.Log("SECONDARY ATTACK NIGHTMARE");

        StartCoroutine(NIGHTMARE_SecondaryAttack());
    }

    private IEnumerator NIGHTMARE_SecondaryAttack()
    {
        float timeLeft = 0;
        float percent = 0;
        
        while (Input.GetButton($"PLAYER{p_playerBase._idxPlayer}_SecondaryAttack"))
        {
            if (timeLeft < pr_secondaryAttack_maxLoadingTime)
            {
                timeLeft += Time.deltaTime;
                 percent = timeLeft / pr_secondaryAttack_maxLoadingTime;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Vector3 position = p_playerBase.transform.position;
        Quaternion rotation = p_playerBase.transform.rotation;
        
        GameObject newSlash = Instantiate(pr_secondaryAttack_PrefabAOE, position, rotation,transform);
        ATTACK_AOE attackBase = newSlash.GetComponent<ATTACK_AOE>();
        attackBase.BASEWEAPONOWNER = this ;
            
        attackBase.Initialize(gameObject,p_secondaryAttack_AOEDuration, p_secondaryAttack_AttackDamage,p_secondaryAttack_RadiusAttack);
    }
    
   
    
    public override void WEAPON_UltimeAttack()
    {
        Debug.Log("ULTIME ATTACK NIGHTMARE");
    }
}
