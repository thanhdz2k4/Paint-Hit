using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRound : MonoBehaviour
{
    [SerializeField]
    List<GameObject> listOfRoundsPrefab;


    [SerializeField]
    List<GameObject> listOfRoundActive;

    [SerializeField]
    Vector3 positionSpawn;

    StackRound stackRound;

    // Start is called before the first frame update
    void Start()
    {
        if(listOfRoundsPrefab.Count == 0)
        {
            Debug.LogError("List of round must be greater 0");
        }
        stackRound = GetComponent<StackRound>();
    }

    public void Spawn()
    {
        GameObject newRound = Instantiate(listOfRoundsPrefab[Random.Range(0, listOfRoundsPrefab.Count)]);
        newRound.transform.position = positionSpawn;
        listOfRoundActive.Add(newRound);

        StackRoundWhenFinish();
    }

    private void StackRoundWhenFinish()
    {
        foreach(var obj in listOfRoundActive)
        {
            stackRound.StackRounds(obj);
        }
    }
}
