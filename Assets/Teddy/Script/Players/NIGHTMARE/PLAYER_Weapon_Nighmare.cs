using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Weapon_Nighmare : PLAYER_Weapon
{
    [Header("WEAPON NIGHTMAARE")]
    [SerializeField] private GameObject p_projectile;
    [SerializeField] private float p_projectileDuration = 0.5f;
    [SerializeField] private float p_projectileSpeed= 5f;


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
            
            attackBase.Initialize(gameObject, p_projectileDuration, p_projectileSpeed, 5);
            StartCoroutine(ReloadPrimaryAttack());
        }
    }

    public override void WEAPON_SecondaryAttack()
    {
        Debug.Log("SECONDARY ATTACK NIGHTMARE");
    }
    
    public override void WEAPON_UltimeAttack()
    {
        Debug.Log("ULTIME ATTACK NIGHTMARE");
    }
}
