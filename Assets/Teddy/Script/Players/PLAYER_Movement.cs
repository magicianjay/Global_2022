using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PLAYER_Movement : MonoBehaviour
{
    [SerializeField] protected float pr_Speed = 10f;
    [SerializeField] protected float pr_dashPower = 5f;
    protected bool pr_inDash = false;

    public bool INDASH {
        get
        {
            return pr_inDash;
        }
        set
        {
            pr_inDash = value;
        }
}
    
    public virtual void Movement_Move(string XAxis,string YAxis)
    {
        if (!pr_inDash)
        {
            float horizontalAxis = Input.GetAxis(XAxis);
            float verticalAxis = -Input.GetAxis(YAxis);

            float addSpeedX = horizontalAxis * pr_Speed * Time.deltaTime;
            float addSpeedY = verticalAxis * pr_Speed * Time.deltaTime;

            Vector2 movement = new Vector2(addSpeedX, addSpeedY);
            this.transform.Translate(movement, Space.World); //+= new Vector3(addSpeedX,addSpeedY,0);
        }
    }


    public abstract void MOVEMENT_Dash();

    public void Movement_Lookat(string _horizontalAxis, string _verticalAxis)
    {
        float horizontalAxis = Input.GetAxis(_horizontalAxis);
        float verticalAxis = -Input.GetAxis(_verticalAxis);
        
        Vector3 direction = new Vector3(horizontalAxis,verticalAxis  ,90);
        
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * direction;
        
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
        
    }
}
