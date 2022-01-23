using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARENA_Waves : MonoBehaviour
{ 
  public List<WaveObject>  waves;
  public int actualWaves;
  public int numberOfEnnemiesInWave;
    
  private void OnEnable()
  {
    ENEMY_Base.OnEnemyKilled += EnemyKill;
    ARENA_Base.OnStartArena += StartArenaWave;
  }
  
  private void EnemyKill()
  {
        
  }

  private void StartArenaWave()
  {
    actualWaves = 0;
    numberOfEnnemiesInWave = waves[actualWaves].waveEnemies.Count;
  }
  
  
  
  
  
  
  
  
  
}

[System.Serializable]
public class WaveObject
{
  public List<GameObject> waveEnemies;
}
