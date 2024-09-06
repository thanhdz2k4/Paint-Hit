using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHurdlers : MonoBehaviour
{
    [SerializeField]
    int maxOfNumberHurdler;

    [SerializeField]
    private Color colorOfHurdler;

    [SerializeField]
    ColorHandler colorHandler;

   

    public void MakeHurdler(GameObject round)
    {
        colorOfHurdler = colorHandler.currentColorArray[0];
        int numberOfHurdles = Random.Range(1, maxOfNumberHurdler);

        List<int> hurdlesList = new List<int>();

        for (int i = 0; i < numberOfHurdles; i++)
        {
            hurdlesList.Add(Random.Range(1, 22));
        }

        for (int i = 0; i < hurdlesList.Count; i++)
        {
            round.transform.GetChild(hurdlesList[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            round.transform.GetChild(hurdlesList[i]).gameObject.GetComponent<MeshRenderer>().material.color = colorOfHurdler;
            round.transform.GetChild(hurdlesList[i]).gameObject.tag = "red";
        }
    } 
}
