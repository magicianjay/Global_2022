using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Body : MonoBehaviour
{
    [SerializeField] protected float pr_vitality = 100;
    [SerializeField] protected float pr_stamina = 100;

    private float p_vitalityBase;
    private float p_staminaBase;

    public void Initialize()
    {
        p_vitalityBase = pr_vitality ;
        p_vitalityBase = pr_stamina;
    }
    
    public virtual void CollisionWithAttack(GameObject ownerAttack,BASE_Weapon baseWeapon)
    {
        Debug.Log("PLAYER : I AM ATTACKED");
     
        if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Enemy)
        {
            ENEMY_Weapon enemyWeapon = baseWeapon.GetComponent<ENEMY_Weapon>();
            pr_vitality -= enemyWeapon.WEAPON_DAMAGE;
            Debug.Log("UN ENNEMI M'ATTAQUE");
        }
        else if (baseWeapon._typeOwner == BASE_Weapon.TypeOwner.Player)
        {
            Debug.Log("UN PLAYER M'ATTAQUE");
        }
    }
    
}
