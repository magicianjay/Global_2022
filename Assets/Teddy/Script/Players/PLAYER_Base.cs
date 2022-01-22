using System;
using UnityEngine;

public class PLAYER_Base : MonoBehaviour
{
    [SerializeField]private int _idxPlayer = 0;
    [SerializeField]private PLAYER_Movement _myPlayerMovement;
    [SerializeField]private PLAYER_Weapon _myPlayerWeapon;
    [SerializeField]private PLAYER_Body _myPlayerBody;

    public PLAYER_Movement PLAYER_MOVEMENT => _myPlayerMovement;
    public PLAYER_Weapon PLAYER_WEAPON => _myPlayerWeapon;
    public PLAYER_Body PLAYER_BODY => _myPlayerBody;

    private void Awake()
    {
        _myPlayerBody.Initialize();
        _myPlayerWeapon.Initialize();
    }

    public virtual void Update()
    {
        if (Input.GetAxis($"PLAYER{_idxPlayer}_HorizontalAxis_LeftStick") != 0)
        {
            _myPlayerMovement.Movement_Move($"PLAYER{_idxPlayer}_HorizontalAxis_LeftStick",$"PLAYER{_idxPlayer}_VerticalAxis_LeftStick");
        }

        if (Input.GetAxis($"PLAYER{_idxPlayer}_HorizontalAxis_RightStick") != 0 || Input.GetAxis($"PLAYER{_idxPlayer}_VerticalAxis_RightStick") != 0)
        {
            LookAt($"PLAYER{_idxPlayer}_HorizontalAxis_RightStick",$"PLAYER{_idxPlayer}_VerticalAxis_RightStick");
        }

        if (Input.GetButton($"PLAYER{_idxPlayer}_PrimaryAttack"))
        {
            _myPlayerWeapon.WEAPON_PrimaryAttack();
        }
        if (Input.GetButtonDown($"PLAYER{_idxPlayer}_SecondaryAttack"))
        {
            _myPlayerWeapon.WEAPON_SecondaryAttack();
        }
        if (Input.GetButtonDown($"PLAYER{_idxPlayer}_UltimateAttack"))
        {
            _myPlayerWeapon.WEAPON_UltimeAttack();
        }
        if (Input.GetButtonDown($"PLAYER{_idxPlayer}_Dash"))
        {
            _myPlayerMovement.MOVEMENT_Dash();
        }
    }

   
    private void LookAt(string _horizontalAxis, string _verticalAxis )
    {
        float horizontalAxis = Input.GetAxis(_horizontalAxis) > 0.1f || Input.GetAxis(_horizontalAxis) < 0.1f? Input.GetAxis(_horizontalAxis):0;
        float verticalAxis = -Input.GetAxis(_verticalAxis) > 0.1f || -Input.GetAxis(_verticalAxis) < 0.1f ? -Input.GetAxis(_verticalAxis):0;
        
        Vector3 direction = new Vector3(horizontalAxis,verticalAxis  ,90);
    
        
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * direction;
        
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
        
    }
}
