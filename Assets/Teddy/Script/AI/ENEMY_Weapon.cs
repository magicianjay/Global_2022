using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_Weapon : BASE_Weapon
{
    public void Initialize()
    {
        _typeOwner = TypeOwner.Enemy;
    }
}
