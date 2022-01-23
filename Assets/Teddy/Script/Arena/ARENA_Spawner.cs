using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARENA_Spawner : MonoBehaviour
{
    private void Start()
    {
        ARENA_Waves.Instance.allSpawners.Add(gameObject);
    }
}
