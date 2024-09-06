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

    private int countRound = 0;
    private void Awake()
    {
        stackRound = GetComponent<StackRound>();
        spawnRound = GetComponent<SpawnRound>();
        makeHurdlers = GetComponent<MakeHurdlers>();
    }

    public void SpawnRound()
    {
        GameObject newRound = spawnRound.Spawn();
        listOfRounds.Add(newRound);
        MakeHurdlers(newRound, countRound);
        StackRounds(listOfRounds);
        countRound++;
    }

    private void StackRounds(List<GameObject> listOfRounds)
    {
        foreach(var obj in listOfRounds)
        {
            stackRound.Stack(obj);
        }
    }

    private void MakeHurdlers(GameObject round, int index)
    {
        makeHurdlers.MakeHurdler(round, index);
    }
}
