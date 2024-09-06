using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    BallHandler BallHandler;

    [SerializeField]
    UIHandler UIHandler;

    [SerializeField]
    RoundController roundController;

    [SerializeField]
    GameObject buttonSpawnBall;

   

    private int countBall = 0;
    private int countRound = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        // count ball to check complete round
        countBall++;

        BallHandler.SpawnBall();

        // if count ball is empty, it will create a new round
        CheckCompleteRound();

    }

    private void CheckCompleteRound()
    {
        if(countBall == LevelHandler.Instance.ballCounts)
        {
            StartCoroutine(Delay());
        }
    }


    // Delay spawn ball and create new round
    IEnumerator Delay()
    {
        buttonSpawnBall.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        CreateRound();
        buttonSpawnBall.SetActive(true);
    }

    private void CreateRound()
    {

        roundController.SpawnRound();

        // count round to check complete level  
        countRound++;

    }
}
