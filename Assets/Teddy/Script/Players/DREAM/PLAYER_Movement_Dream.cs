using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Movement_Dream : PLAYER_Movement
{
    [SerializeField] private float _TimeDash;
    
    public override void MOVEMENT_Dash()
    {
//      Debug.Log("DASH DREAM");
      
      StartCoroutine(DashDream());
    }

    private IEnumerator DashDream()
    {
        pr_inDash = true;
        bool dashInProgress = true;
        float timeLeft = 0;
        float timeDash = _TimeDash;

        Vector3 startPosition = transform.position;
        Vector3 goalPosition = transform.position + (transform.right * pr_dashPower);
        
        while (dashInProgress)
        {
            dashInProgress = timeLeft < timeDash;
            timeLeft += Time.deltaTime;

            float percent = timeLeft / timeDash;
            Vector3 lerp = Vector3.Lerp(startPosition, goalPosition, percent);

            transform.position = lerp;
            
            yield return new WaitForSeconds(Time.deltaTime);
        }
//        Debug.Log("DashFinished");
        pr_inDash = false;
    }
}
