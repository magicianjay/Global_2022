using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Weapon_Dream : PLAYER_Weapon
{
    [Header("WEAPON DREAM ")]
    //SerializeField] private Vector2 p_sizeCollider;
    [SerializeField] private GameObject p_slash;
    [SerializeField] private float p_slashDuration = 0.5f;
    
    [Header("SECONDARY ATTACK NIGHTMARE")]
    [SerializeField] protected float pr_cooldownSecondaryAttack = 3f;
    private float p_cooldownSecondaryAttackBase = 3f;
    [SerializeField] protected float pr_maxLoadingTime = 3f;
    [SerializeField] private float p_attackPower_SecondaryAttack = 5;
    [SerializeField] private float p_dashPower_SecondaryAttack = 5;
    [SerializeField] private float p_dashTime_SecondaryAttack = 0.2f;
    
     public override void Initialize(PLAYER_Base playerBase)
     {
         base.Initialize(playerBase);
         p_cooldownSecondaryAttackBase = pr_cooldownSecondaryAttack;
     }
     
    public override void WEAPON_PrimaryAttack()
    {
        if (!p_needReload)
        {
            //        Debug.Log("PRIMARY ATTACK DREAM");
            Vector3 position = transform.position + transform.right;
            Quaternion rotation = transform.rotation;
        
            GameObject newSlash = Instantiate(p_slash, position, rotation,transform);
            ATTACK_Slash attackBase = newSlash.GetComponent<ATTACK_Slash>();
            attackBase.BASEWEAPONOWNER = this ;
            
            attackBase.Initialize(gameObject,p_slashDuration, pr_damage);
            StartCoroutine(ReloadPrimaryAttack());
        }
    }
    
    public override void WEAPON_SecondaryAttack()
    {
        Debug.Log("SECONDARY ATTACK DREAM");
        StartCoroutine(DREAM_SecondaryAttack());
    }
    
    private IEnumerator DREAM_SecondaryAttack()
    {
        float timeLeft = 0;
        float percent = 0;
        
        while (Input.GetButton($"PLAYER{p_playerBase._idxPlayer}_SecondaryAttack"))
        {
            if (timeLeft < pr_maxLoadingTime)
            {
                timeLeft += Time.deltaTime;
                percent = timeLeft / pr_maxLoadingTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        Debug.Log("percent : "+percent);
        float dashpower = p_dashPower_SecondaryAttack * percent;
        float attackPower = Mathf.Abs(p_attackPower_SecondaryAttack * percent);
        Debug.Log("dashpower : "+dashpower);
        StartCoroutine(DREAM_DashAttack(dashpower,attackPower));
    }
    
    private IEnumerator DREAM_DashAttack(float dashPower, float attackpower)
    {
        p_playerBase.PLAYER_MOVEMENT.INDASH = true;
        bool dashInProgress = true;
        float timeLeft = 0;
        float timeDash = p_dashTime_SecondaryAttack;

        Vector3 startPosition = p_playerBase.transform.position;
        Vector3 goalPosition = p_playerBase.transform.position + (transform.right * dashPower );
        
        while (timeLeft < timeDash)
        {
            timeLeft += Time.deltaTime;

            float percent = timeLeft / timeDash;
            Vector3 lerp = Vector3.Lerp(startPosition, goalPosition, percent);

            p_playerBase.transform.position = lerp;
            
            yield return new WaitForSeconds(Time.deltaTime);
        }
//        Debug.Log("DashFinished");

        p_playerBase.PLAYER_MOVEMENT.INDASH = false;

        Vector3 position = p_playerBase.transform.position + transform.right;
        Quaternion rotation = p_playerBase.transform.rotation;
        
        GameObject newSlash = Instantiate(p_slash, position, rotation,transform);
        ATTACK_Slash attackBase = newSlash.GetComponent<ATTACK_Slash>();
        attackBase.BASEWEAPONOWNER = this ;
            
        attackBase.Initialize(gameObject,p_slashDuration, attackpower);
    }
    public override void WEAPON_UltimeAttack()
    {
        Debug.Log("ULTIME ATTACK DREAM");
    }
}
