using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Weapon_Dream : PLAYER_Weapon
{
    public override void WEAPON_PrimaryAttack()
    {
        Debug.Log("PRIMARY ATTACK DREAM");
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
