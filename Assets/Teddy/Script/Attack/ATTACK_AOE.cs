using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTACK_AOE : ATTACK_Base
{
    protected float pr_radiusAttack = 3;
    
    public override void Initialize(GameObject ownerAttack, float durationAttack, float attackDamage,float radiusAttack)
    {
        base.Initialize(ownerAttack, durationAttack, attackDamage);
        pr_typeAttack = TypeAttack.Cac;
        pr_radiusAttack = radiusAttack;
        transform.localScale = new Vector3(pr_radiusAttack,pr_radiusAttack,pr_radiusAttack);
    }
    
    protected override void ATTACK_Collision(Collision2D other)
    {
        if (!other.gameObject.Equals(pr_ownerAttack))
        {
            Debug.Log("COLLIDE NOT MY OWNER");
            if (other.gameObject.TryGetComponent<PLAYER_Base>( out PLAYER_Base _playerBase))
            {
                Debug.Log("COLLIDE OTHER PLAYER");
                _playerBase.PLAYER_BODY.CollisionWithAttack(pr_ownerAttack, _baseWeaponOwner,pr_attackDamage);
            }
            else if (other.gameObject.TryGetComponent<ENEMY_Base>( out ENEMY_Base _enemyBase))
            {
                _enemyBase.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner,pr_attackDamage);
            }
            else if (other.gameObject.TryGetComponent<ARENA_Inhibitor>(out ARENA_Inhibitor _arenaInhibitor))
            {
                _arenaInhibitor.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner,pr_attackDamage);
            }
        }
        else
        {
            Debug.Log("COLLIDE MY OWNER");
        }
    }
    
    protected override void ATTACK_Collision(Collider2D collider2D)
    {
        if (!collider2D.gameObject.Equals(pr_ownerAttack))
        {
            Debug.Log("COLLIDE NOT MY OWNER");
            if (collider2D.gameObject.TryGetComponent<PLAYER_Base>( out PLAYER_Base _playerBase))
            {
                Debug.Log("COLLIDE OTHER PLAYER");
                _playerBase.PLAYER_BODY.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner,pr_attackDamage);
            }
            else if (collider2D.gameObject.TryGetComponent<ENEMY_Base>( out ENEMY_Base _enemyBase))
            {
                _enemyBase.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner,pr_attackDamage);
            }
            else if (collider2D.gameObject.TryGetComponent<ARENA_Inhibitor>(out ARENA_Inhibitor _arenaInhibitor))
            {
                
            }
        }
        else
        {
            Debug.Log("COLLIDE MY OWNER");
        }
    }
}
