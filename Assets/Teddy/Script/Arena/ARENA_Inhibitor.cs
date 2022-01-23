using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARENA_Inhibitor : MonoBehaviour
{
    public delegate void ARENA_InhibitorDestroyed();
    public static event ARENA_InhibitorDestroyed OnInhibitorDestroyed;

    [SerializeField] private float p_Vitality = 200;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        UI_IG.Instance.InitializeInhibitor((int)VITALITY);
    }
    
    public float VITALITY
    {
        get
        {
            return p_Vitality;
        }
        set
        {
            p_Vitality = value;
            VerifyVitality();
        }
    }
    
    
    public virtual void CollisionWithAttack(GameObject ownerAttack,BASE_Weapon baseWeapon, float attackDamage)
    {
      //  Debug.Log("INHIBITEUR : I AM ATTACKED");
     
        if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Enemy)
        {
            VITALITY -= attackDamage;
           // Debug.Log("UN ENNEMI M'ATTAQUE : "+attackDamage);
        }
    }

    private void VerifyVitality()
    {
        if (VITALITY <= 0)
        {
          if(OnInhibitorDestroyed!=null)OnInhibitorDestroyed.Invoke();
        }
        else
        {
           // Debug.Log(VITALITY);
            UI_IG.Instance.SetInhibitorUI((int)VITALITY);
        }
    }
}
