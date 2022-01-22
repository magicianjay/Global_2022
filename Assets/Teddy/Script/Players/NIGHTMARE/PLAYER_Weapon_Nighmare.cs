using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Weapon_Nighmare : PLAYER_Weapon
{
    public override void WEAPON_PrimaryAttack()
    {
        Debug.Log("PRIMARY ATTACK NIGHTMARE");
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
