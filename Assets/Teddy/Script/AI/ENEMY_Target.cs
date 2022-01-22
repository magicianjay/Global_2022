using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_Target : MonoBehaviour
{
    public delegate void ENEMYTARGET_TargetDestoy();
    public event ENEMYTARGET_TargetDestoy OnTargetDestoy;

    public void TargetDestroy()
    {
        if(OnTargetDestoy != null)OnTargetDestoy.Invoke();
    }
}
