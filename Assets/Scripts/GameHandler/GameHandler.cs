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
    ColorHandler colorHandler;

    [SerializeField]
    ParticleSystem vfxSplash;



    [SerializeField]
    private int countBall = 0;

    [SerializeField]
    private int countRound = 0;
    // Start is called before the first frame update
    void Start()
    {
        UIHandler.SetTotalRoundTxt((countRound).ToString(), LevelHandler.Instance.totalCircles.ToString());
        //CreateRound();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCompleteLevel();
        CheckFailLevel();
        Debug.Log("Level: " + LevelHandler.Instance.isHardLevel) ;

    }

    public void SpawnBall()
    {
        // count ball to check complete round
        countBall++;

        // spawn ball
        BallHandler.SpawnBall();

        // delete ball count ui
        UIHandler.UpdateBallCountUI();

        // if count ball is empty, it will create a new round
        CheckCompleteRound();

        StartCoroutine(DelaySplashVFX());
        

    }

    IEnumerator DelaySplashVFX()
    {
        yield return new WaitForSeconds(0.3f);
        vfxSplash.startColor = colorHandler.currentColor;
        vfxSplash.Play();
    }

    private void CheckCompleteRound()
    {
        if(countBall == LevelHandler.Instance.ballCounts)
        {
            
            StartCoroutine(DelayCompleteRound());
        }
    }

    // check compplete level if player pass count of round
    private void CheckCompleteLevel()
    {
       
        if (countRound == LevelHandler.Instance.totalCircles + 1)
        {
            UIHandler.ActiveSuccessScreen();
            
        }
    }

    private void CheckFailLevel()
    {
        if (LevelHandler.Instance.hearts <= 0)
        {
            UIHandler.ActiveFailScreen(true);
            LevelHandler.Instance.FailGame();
            LevelHandler.Instance.UpgradeLevel();
            ResetLevel();
        }
        
    }


    // Delay spawn ball and create new round
    IEnumerator DelayCompleteRound()
    {
        UIHandler.ActiveButtonSpawnBall(false);
        yield return new WaitForSeconds(0.4f);

        roundController.SetColorInCurrentRound();
        roundController.PauseTween();
        CreateRound();
        UIHandler.InitBallCountUI(LevelHandler.Instance.ballCounts);
        
        UIHandler.ActiveButtonSpawnBall(true);
    }

    // create new round when complete round or level
    public void CreateRound()
    {
        // Create a new round
        roundController.SpawnRound();

        // count round to check complete level  
        countRound++;

        // reset count ball
        countBall = 0;

        UIHandler.SetTotalRoundTxt((countRound - 1).ToString(), LevelHandler.Instance.totalCircles.ToString());

    }

    // if player finish level,the new level will be updated;
    public void UpdateLevel ()
    {
        // reset color
        colorHandler.ChangeColor();

        // reset current rounds in screen
        roundController.DeleleAllRound();

        // reset ball count ui
        UIHandler.DeleteAllBallCountUI();

        // update text in complete level screen;
        UIHandler.SetTextInCompleteLevelScreen("Complete Level " + LevelHandler.Instance.currentLevel);


        if(LevelHandler.Instance.hearts >= 0)
        {
            // update level in playPrep;
            LevelHandler.Instance.NextLevel();
            LevelHandler.Instance.UpgradeLevel();
        }

        // update ball count ui
        UIHandler.InitBallCountUI(LevelHandler.Instance.ballCounts);

        // create a new round
        CreateRound();

        // reset count round
        countRound = 1;

        // update total round and count round text
        UIHandler.SetTotalRoundTxt((countRound - 1).ToString(), LevelHandler.Instance.totalCircles.ToString());
    }

    public void ResetLevel()
    {
        // reset color
        colorHandler.ChangeColor();

        // reset current rounds in screen
        roundController.DeleleAllRound();

        // reset ball count ui
        UIHandler.DeleteAllBallCountUI();

        UIHandler.DeleteAllChildren();

        // reset heart ui 
        UIHandler.DeleteAllHeartUI();

        LevelHandler.Instance.FailGame();
        LevelHandler.Instance.UpgradeLevel();

        // update text in complete level screen;
        UIHandler.SetTextInCompleteLevelScreen("Complete Level " + LevelHandler.Instance.currentLevel);

        // update ball count ui
        UIHandler.InitBallCountUI(LevelHandler.Instance.ballCounts);

        // create new heartUI
        UIHandler.InitHeartUI(LevelHandler.Instance.hearts);

        PlayerPrefs.SetInt("Level", 1);

        // create a new round
        CreateRound();

        // reset count round
        countRound = 1;

        // update total round and count round text
        UIHandler.SetTotalRoundTxt((countRound - 1).ToString(), LevelHandler.Instance.totalCircles.ToString());
    }




}
