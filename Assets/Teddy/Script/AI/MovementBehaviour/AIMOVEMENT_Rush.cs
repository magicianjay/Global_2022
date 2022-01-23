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
      Vector2 position = transform.position;
      Vector2 targetPosition = p_enemyBase.TARGETBEHAVIOUR.TARGET.transform.position;

      Vector2 direction = targetPosition - position;
      float directionMagnitude = direction.magnitude;
      
      if (directionMagnitude>2)
      {
         Vector2 directionNorm = direction.normalized;
      
         float powerMovement = pr_speed * Time.deltaTime;
      
         this.transform.Translate(directionNorm*powerMovement,Space.World);
      }

   }
}
