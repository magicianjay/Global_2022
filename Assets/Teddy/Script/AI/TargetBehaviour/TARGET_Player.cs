using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TARGET_Player : ENEMY_TargetBehaviour
{
    protected override void ENEMY_FOUNDTARGET()
    {
        Debug.Log("SEARCH TARGET");

        PLAYER_Base[] allPlayers= FindObjectsOfType<PLAYER_Base>();

        PLAYER_Base closedPlayer = allPlayers.Length !=0 ? allPlayers[0]:null;
        float bestDistance = Mathf.Infinity;
  
        foreach (var VARIABLE in allPlayers)
        {
            float distance = (transform.position - VARIABLE.transform.position).magnitude;

            if (distance < bestDistance)
            {
                bestDistance = distance;
                closedPlayer = VARIABLE;
            }
        }

        if (closedPlayer != null)
        {
            pr_tTarget = closedPlayer.GetComponent<ENEMY_Target>();
            pr_tTarget.OnTargetDestoy += TARGET_Destroyed;
            Debug.Log("FIND TARGET : "+pr_tTarget,pr_tTarget);
        }
        else
        {
            Debug.Log("NO POTENTIAL TARGET");
        }
    }

    protected override void ENEMY_UPDATETARGET()
    {
        Debug.Log("UPDATE TARGET");
        pr_tTarget.OnTargetDestoy -= TARGET_Destroyed;
        pr_tTarget = null;

        ENEMY_FOUNDTARGET();
    }
}
