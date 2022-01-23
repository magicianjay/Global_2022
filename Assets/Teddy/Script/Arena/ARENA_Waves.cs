using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ARENA_Waves : MonoBehaviour
{ 
  public delegate void ARENA_NewWave();
  public static event ARENA_NewWave OnNewWave;
  
  public static ARENA_Waves Instance { get; private set; }
  public List<WaveObject>  waves;
  public float _newWaveTimer = 20f;
  
  public int numberOfEnnemiesInWave;
  public int leftEnnemies;
    
  public int actualWaves;
  public int actualGroup;

  public float timeSpawnPerGroup = 10f;
  public float timeSpawnPerUnit = 0.5f;

  public List<GameObject> allSpawners;

  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    Initialize();
  }

  public void Initialize()
  {
    UI_IG.Instance.InitializeWave(0,actualWaves);
  }
  
  private void OnEnable()
  {
    ENEMY_Base.OnEnemyKilled += EnemyKill;
    ARENA_Base.OnStartArena += StartArenaWave;
  }
  
  private void EnemyKill()
  {
    numberOfEnnemiesInWave--;

    if (numberOfEnnemiesInWave == 0)
    {
      Debug.Log("WavesFinished");
      actualWaves++;
      if (actualWaves < waves.Count)
      {
        StartCoroutine(TimerNewWave());
      }
      else
      {
        Debug.Log("FINISHED GAME");
      }
     
    }
  }

  private IEnumerator TimerNewWave()
  {
    yield return new WaitForSeconds(_newWaveTimer);
    NewWave();
  }
  
  private void NewWave()
  {
    OnNewWave?.Invoke();
    actualWaves++;
    //Debug.Log("NewWave : "+actualWaves);
    
    numberOfEnnemiesInWave = 0;
    actualGroup = 0;
    
    foreach (var VARIABLE in waves[actualWaves].waveGroups)
    {
      numberOfEnnemiesInWave += VARIABLE.waveEnemies.Count;
    }

    UI_IG.Instance.SetWaveUI(0,actualWaves);
    
    StartCoroutine(SpawningWaveGroup());
  }
  private void StartArenaWave()
  {
    StartCoroutine(Wait());
    
  }

  private IEnumerator Wait()
  {
    yield return new WaitForSeconds(10);
    numberOfEnnemiesInWave = 0;
    actualWaves = 0;
    actualGroup = 0;
    
    foreach (var VARIABLE in waves[actualWaves].waveGroups)
    {
      numberOfEnnemiesInWave += VARIABLE.waveEnemies.Count;
    }

    StartCoroutine(SpawningWaveGroup());
  }
  private IEnumerator SpawningWaveGroup()
  {
    int maxGroup = waves[actualWaves].waveGroups.Count;
    
    for (int i = 0; i < maxGroup; i++)
    {
      //Debug.Log("SPAWN A GROUP");
      GameObject chosenSpawner = FindRandomSpawner();
      StartCoroutine(SpawningGroup(actualGroup,chosenSpawner));
      actualGroup++;
      yield return new WaitForSeconds(timeSpawnPerGroup);
    }
  }
  
  private IEnumerator SpawningGroup(int _actualGroup, GameObject spawner)
  {
    int unitSpawn = 0;
    int unitSpawnMax =  waves[actualWaves].waveGroups[_actualGroup].waveEnemies.Count;
    
    for (int i = 0; i < unitSpawnMax; i++)
    {
//      Debug.Log("SPAWN A UNIT");
      Instantiate(waves[actualWaves].waveGroups[_actualGroup].waveEnemies[i],spawner.transform.position,quaternion.identity );
      unitSpawn++;
      yield return new WaitForSeconds(timeSpawnPerUnit);
    }
  }

  private GameObject FindRandomSpawner()
  {
    int numberOfSpawners = allSpawners.Count ;
    
    int rand = Random.Range(0, numberOfSpawners);

    GameObject chosenSpawner = allSpawners[rand];
    return chosenSpawner;
  }
  
  
  
}

[System.Serializable]
public class WaveObject
{
  public List<WaveGroup> waveGroups;
}

[System.Serializable]
public class WaveGroup
{
  public List<GameObject> waveEnemies;
}
