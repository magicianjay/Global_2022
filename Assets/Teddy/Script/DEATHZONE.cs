using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATHZONE : MonoBehaviour
{
    public static DEATHZONE Instance { get; private set; }

    public List<GameObject> allObjectsInDeathZone;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void MoveObjectToDeathZone(GameObject deadObject)
    {
        allObjectsInDeathZone.Add(deadObject);
        deadObject.transform.SetParent(transform);
        deadObject.SetActive(false);
    }
    
}
