using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRound : MonoBehaviour
{
    [SerializeField]
    List<GameObject> listOfRoundsPrefab;

    [SerializeField]
    Vector3 positionSpawn;

    

    // Start is called before the first frame update
    void Start()
    {
        if(listOfRoundsPrefab.Count == 0)
        {
            Debug.LogError("List of round must be greater 0");
        }    
    }

    public GameObject Spawn()
    {
        GameObject newRound = Instantiate(listOfRoundsPrefab[Random.Range(0, listOfRoundsPrefab.Count)]);
        newRound.transform.position = positionSpawn;

        return newRound;
        
    }

    
}
