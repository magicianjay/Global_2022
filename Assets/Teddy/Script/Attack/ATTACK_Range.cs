using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTACK_Range : ATTACK_Base
{
    [Header("ATTACK RANGE")]
    [SerializeField] protected int pr_piercingNumber;
    protected int _piercedEntity = 0;
    [SerializeField] protected float pr_speed;
    
    public override void Initialize(GameObject ownerAttack, float durationAttack,float speed, int piercingNumber)
    {
        base.Initialize(ownerAttack, durationAttack);
        pr_typeAttack = TypeAttack.Distance;
        pr_piercingNumber = piercingNumber;
        pr_speed = speed;

        StartCoroutine(ATTACK_Movement());
    }
    
    protected override void ATTACK_Collision(Collision2D other)
    {
        if (!other.gameObject.Equals(pr_ownerAttack))
        {
            Debug.Log("COLLIDE NOT MY OWNER");
            if (other.gameObject.TryGetComponent<PLAYER_Base>( out PLAYER_Base _playerBase))
            {
                Debug.Log("COLLIDE OTHER PLAYER");
                _playerBase.PLAYER_BODY.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner);
            }
            else if (other.gameObject.TryGetComponent<ENEMY_Base>( out ENEMY_Base _enemyBase))
            {
                _enemyBase.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner);
            }

            _piercedEntity++;
            if (_piercedEntity >= pr_piercingNumber )
            {
                Destroy(gameObject);
                Debug.Log("ATTACK Death by collision");
            }
        }
        else
        {
            Debug.Log("COLLIDE MY OWNER");
        }
    }

    
    protected override void ATTACK_Collision(Collider2D collider2Dr)
    {
        if (!collider2Dr.gameObject.Equals(pr_ownerAttack))
        {
            Debug.Log("COLLIDE NOT MY OWNER");
            if (collider2Dr.gameObject.TryGetComponent<PLAYER_Base>( out PLAYER_Base _playerBase))
            {
                Debug.Log("COLLIDE OTHER PLAYER");
                _playerBase.PLAYER_BODY.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner);
            }
            else if (collider2Dr.gameObject.TryGetComponent<ENEMY_Base>( out ENEMY_Base _enemyBase))
            {
                _enemyBase.CollisionWithAttack(pr_ownerAttack,_baseWeaponOwner);
            }

            _piercedEntity++;
            if (_piercedEntity >= pr_piercingNumber )
            {
                Destroy(gameObject);
                Debug.Log("ATTACK Death by collision");
            }
        }
        else
        {
            Debug.Log("COLLIDE MY OWNER");
        }
    }
    
    protected virtual IEnumerator ATTACK_Movement()
    {
        while (true)
        {
            Vector3 movement = Vector3.right * Time.deltaTime*pr_speed;
            this.transform.Translate(movement, Space.Self); 
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
    }
}
