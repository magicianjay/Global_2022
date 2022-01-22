using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATTACK_Base : MonoBehaviour
{
    [Header("ATTACK BASE")]
     protected GameObject pr_ownerAttack;
     protected float pr_timeDuration = 0;
     protected float pr_attackDamage = 0;

    protected BASE_Weapon _baseWeaponOwner;

    public BASE_Weapon BASEWEAPONOWNER
    {
        get {return _baseWeaponOwner; }
        set { _baseWeaponOwner = value; }
    }

    public enum TypeAttack{Distance, Cac}
    protected TypeAttack pr_typeAttack;
    
    public virtual void Initialize(GameObject ownerAttack,float durationAttack, float attackDamage)
    {
        pr_ownerAttack = ownerAttack;
        pr_attackDamage = attackDamage;
        
        Collider2D attackCollider = this.GetComponent<Collider2D>();
        Collider2D ownerCollider = ownerAttack.GetComponent<Collider2D>();
        
        if (attackCollider != null && ownerCollider != null)
        {
            Physics2D.IgnoreCollision(attackCollider,ownerCollider);
        }
        
        pr_timeDuration = durationAttack;

        if(pr_timeDuration > 0){StartCoroutine(ATTACK_DurationDestroy());}
    }

    public virtual void Initialize(GameObject ownerAttack, float durationAttack,float attackDamage,float speed, int piercingNumber)
    {
        pr_ownerAttack = ownerAttack.transform.parent.gameObject;
        pr_timeDuration = durationAttack;
        pr_attackDamage = attackDamage;
        
        Collider2D attackCollider = this.GetComponent<Collider2D>();
        Collider2D ownerCollider = ownerAttack.GetComponent<Collider2D>();
        
        if (attackCollider != null && ownerCollider != null)
        {
            Physics2D.IgnoreCollision(attackCollider,ownerCollider);
        }
        
        if(pr_timeDuration > 0){StartCoroutine(ATTACK_DurationDestroy());}
    }

    public virtual void Initialize(GameObject ownerAttack, float durationAttack, float attackDamage, float radiusAttack)
    {
        pr_ownerAttack = ownerAttack;
        pr_attackDamage = attackDamage;
        
        Collider2D attackCollider = this.GetComponent<Collider2D>();
        Collider2D ownerCollider = ownerAttack.GetComponent<Collider2D>();
        
        if (attackCollider != null && ownerCollider != null)
        {
            Physics2D.IgnoreCollision(attackCollider,ownerCollider);
        }
        
        pr_timeDuration = durationAttack;

        if(pr_timeDuration > 0){StartCoroutine(ATTACK_DurationDestroy());}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ATTACK_Collision(other);
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        ATTACK_Collision(collider2D);
    }
    protected abstract void ATTACK_Collision(Collision2D other);
    protected abstract void ATTACK_Collision(Collider2D collider2D);
    

    private IEnumerator ATTACK_DurationDestroy()
    {
        bool finished = false;

        float timeleft = 0;
        
        while (!finished)
        {
            timeleft += Time.deltaTime;
            if (timeleft > pr_timeDuration)
            {
                finished = true;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
//        Debug.Log("ATTACK Death by duration");
        Destroy(gameObject);
    }
}
