using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Weapon_Dream : PLAYER_Weapon
{
    [Header("WEAPON DREAM ")]
    //SerializeField] private Vector2 p_sizeCollider;
    [SerializeField] private GameObject p_slash;
    [SerializeField] private float p_slashDuration = 0.5f;
    
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
            
            attackBase.Initialize(gameObject,p_slashDuration);
            StartCoroutine(ReloadPrimaryAttack());
        }
    }

    
    
    public override void WEAPON_SecondaryAttack()
    {
        Debug.Log("SECONDARY ATTACK DREAM");
    }
    
    public override void WEAPON_UltimeAttack()
    {
        Debug.Log("ULTIME ATTACK DREAM");
    }
}
