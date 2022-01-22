using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BASE_Weapon : MonoBehaviour
{
   public enum TypeOwner { Player, Enemy };

   public TypeOwner _typeOwner;
   
   [Header("PRIMARY ATTACK VALUES")]
   [SerializeField] protected float pr_damage = 100f;

   public float WEAPON_DAMAGE => pr_damage;
   [SerializeField] protected float pr_fireRate = 100f;
}
