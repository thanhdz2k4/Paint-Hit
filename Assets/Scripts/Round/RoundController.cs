using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    StackRound stackRound;

    [SerializeField]
    SpawnRound spawnRound;

    [SerializeField]
    MakeHurdlers makeHurdlers;

    [SerializeField]
    List<GameObject> listOfRounds = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        stackRound = GetComponent<StackRound>();
        spawnRound = GetComponent<SpawnRound>();
        makeHurdlers = GetComponent<MakeHurdlers>();
    }

    public void SpawnRound()
    {
        GameObject newRound = spawnRound.Spawn();
        listOfRounds.Add(newRound);
        MakeHurdlers(newRound);
        StackRounds(listOfRounds);
    }

    private void StackRounds(List<GameObject> listOfRounds)
    {
        foreach(var obj in listOfRounds)
        {
            stackRound.Stack(obj);
        }
    }

    private void MakeHurdlers(GameObject round)
    {
        makeHurdlers.MakeHurdler(round);
    }
}
