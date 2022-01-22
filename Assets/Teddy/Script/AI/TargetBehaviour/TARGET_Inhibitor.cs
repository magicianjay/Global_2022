using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TARGET_Inhibitor : ENEMY_TargetBehaviour
{
 
 protected override void ENEMY_FOUNDTARGET()
 {
  Debug.Log("SEARCH TARGET");

  ARENA_Inhibitor[] allInhibitors = FindObjectsOfType<ARENA_Inhibitor>();

  ARENA_Inhibitor closedInhibitor = allInhibitors.Length !=0 ? allInhibitors[0]:null;
  float bestDistance = Mathf.Infinity;
  
  foreach (var VARIABLE in allInhibitors)
  {
   float distance = (transform.position - VARIABLE.transform.position).magnitude;

   if (distance < bestDistance)
   {
    bestDistance = distance;
    closedInhibitor = VARIABLE;
   }
  }

  if (closedInhibitor != null)
  {
   pr_tTarget = closedInhibitor.GetComponent<ENEMY_Target>();
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
