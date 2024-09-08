using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField]
    SpawnBall spawnBall;

    [SerializeField]
    ColorHandler colorHandler;
    // Start is called before the first frame update
    void Start()
    {
        if(spawnBall == null)
        {
            spawnBall = GetComponent<SpawnBall>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        spawnBall.Spawn();
        
    }
}
