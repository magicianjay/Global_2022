using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Movement_Nightmare : PLAYER_Movement
{
    public override void MOVEMENT_Dash()
    {
//        Debug.Log("DASH NIGHTMARE");
        pr_inDash = true;
        Vector3 dash = pr_dashPower * transform.right;
          
        this.transform.Translate(dash, Space.World);
        pr_inDash = false;
    }
}
