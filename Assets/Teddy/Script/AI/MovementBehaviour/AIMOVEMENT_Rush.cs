using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMOVEMENT_Rush : ENEMY_MovementBehavior
{
   public void Update()
   {
      if (p_startMove)
      {
         MOVEMENT_Move();
      }
   }

   public override void MOVEMENT_Move()
   {
      
   }
}
