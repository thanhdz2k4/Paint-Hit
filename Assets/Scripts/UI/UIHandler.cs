using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    RectTransform heartSpace;

    [SerializeField]
    RectTransform ballCountsSpace;

    [SerializeField]
    GameObject BallCountPrefab;

    [SerializeField]
    GameObject HeartPrefab;

    [SerializeField]
    GameObject SuccessMiniScreen;

    [SerializeField]
    GameObject buttonSpawnBall;

    [SerializeField]
    GameObject FailScreen;

    [SerializeField]
    TMP_Text TextCompleteLevel;

    [SerializeField]
    TMP_Text TextLevel;

    [SerializeField]
    TMP_Text TextTarget;

    [SerializeField]
    TMP_Text totalRoundTxt;

    [SerializeField]
    TMP_Text recordEasyLvTxt;

    [SerializeField]
    TMP_Text recordHardLvTxt;

    [SerializeField]
    ColorHandler colorHandler;

    [SerializeField]
    List<GameObject> listOfBallCountUI;
    [SerializeField]
    List<GameObject> listOfHeartUI;
    
    

    


    // Start is called before the first frame update
    void Start()
    {
        InitBallCountUI(LevelHandler.Instance.ballCounts);
        InitHeartUI(LevelHandler.Instance.hearts);
        UpdateTextInRecord();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTextInRecord()
    {
        this.recordEasyLvTxt.text = "Your record in easy level: " + PlayerPrefs.GetInt("EasyLevel");
        this.recordHardLvTxt.text = "Your record in hard level: " + PlayerPrefs.GetInt("HardLevel");
    }

    public void InitBallCountUI(int size)
    {
        listOfBallCountUI = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject ball = Instantiate(BallCountPrefab, Vector3.zero, Quaternion.identity);
            ball.GetComponent<Image>().color = colorHandler.currentColor;
            ball.transform.SetParent(ballCountsSpace);
            listOfBallCountUI.Add(ball);
        }
    }

    public void InitHeartUI(int size)
    {
        listOfHeartUI = new List<GameObject>();
        for(int i = 0; i < size; i++)
        {
            GameObject heart = Instantiate(HeartPrefab, Vector3.zero, Quaternion.identity);
            heart.transform.SetParent(heartSpace);
            listOfHeartUI.Add(heart);
        }
    }


    public void ActiveSuccessScreen()
    {
        this.SuccessMiniScreen.SetActive(true);
    }

    public void ActiveButtonSpawnBall(bool isActive)
    {
        this.buttonSpawnBall.SetActive(isActive);
    }

    public void SetTextInCompleteLevelScreen(string text)
    {
        this.TextCompleteLevel.text = text;
    }

    public void UpdateBallCountUI()
    {
        Destroy(listOfBallCountUI[0]);
        listOfBallCountUI.RemoveAt(0);
        
    }

    public void DeleteAllBallCountUI()
    {
        foreach(var obj in listOfBallCountUI)
        {
            Destroy(obj);
        }
    }

    public void UpdateHeartUI()
    {
        Destroy(listOfHeartUI[0]);
        listOfHeartUI.RemoveAt(0);
    }

    public void DeleteAllChildren()
    {
        foreach (Transform child in ballCountsSpace)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void DeleteAllHeartUI()
    {
        foreach(var obj in listOfHeartUI)
        {
            Destroy(obj);
        }
    }

    public void UpdateTextInStartGame()
    {
        this.TextLevel.text = "Level " + LevelHandler.Instance.currentLevel;
        this.TextTarget.text = "Target " + LevelHandler.Instance.totalCircles;
    }


    public void SetTotalRoundTxt(string count, string total)
    {
        this.totalRoundTxt.text = count + " / " + total;
    }

    public void ActiveFailScreen(bool isActive)
    {
        this.FailScreen.SetActive(isActive);
    }






}
