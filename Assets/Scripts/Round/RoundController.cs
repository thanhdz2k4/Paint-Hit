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

    [SerializeField]
    ColorHandler colorHandler;

    [SerializeField]
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

    public void SetColorInCurrentRound()
    {
        if(!LevelHandler.Instance.isHardLevel)
        {
            listOfRounds[countRound - 1].transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = colorHandler.currentColor;
        }
        
    }

    public void PauseTween()
    {
        if (!LevelHandler.Instance.isHardLevel)
        {
            listOfRounds[countRound - 1].GetComponent<CircleRotate>().StopRotate();

        }
        
    }

    public void DeleleAllRound()
    {
        countRound = 0;
        foreach(var obj in listOfRounds)
        {
            Destroy(obj);
        }
        listOfRounds = new List<GameObject>();
    }

    private void StackRounds(List<GameObject> listOfRounds)
    {
        if(!LevelHandler.Instance.isHardLevel)
        {
            foreach (var obj in listOfRounds)
            {
                stackRound.Stack(obj);
            }

        }
        
    }

    private void MakeHurdlers(GameObject round, int index)
    {
        makeHurdlers.MakeHurdler(round, index);
    }
}
