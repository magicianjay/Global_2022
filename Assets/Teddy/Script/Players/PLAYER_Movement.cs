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
}
