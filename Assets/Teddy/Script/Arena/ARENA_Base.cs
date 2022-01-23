using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARENA_Base : MonoBehaviour
{
    public delegate void ARENA_Start();
    public static event ARENA_Start OnStartArena;


    
    public void StartGame()
    {
        OnStartArena.Invoke();
    }

    private void OnEnable()
    {
        ARENA_Inhibitor.OnInhibitorDestroyed += InhibitorDestroyed;
    }

    private void OnDisable()
    {
        ARENA_Inhibitor.OnInhibitorDestroyed -= InhibitorDestroyed;
    }

   
    
    private void InhibitorDestroyed()
    {
        Debug.LogWarning("INHIBITOR DESTROYED");
    }
}
