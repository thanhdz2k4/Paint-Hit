using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance { get; private set; }

    public int ballCounts { get; private set; }
    public int totalCircles { get; private set; }
    public float rotateSpeed { get; private set; }
    public int currentLevel { get; private set; }
    public int hearts { get; private set; }

    public bool isHardLevel;
    public bool isStuck { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (PlayerPrefs.GetInt("firstTime", 0) == 0)
        {
            PlayerPrefs.SetInt("fistTime", 1);
            PlayerPrefs.SetInt("Level", 1);
        }

        UpgradeLevel();
        hearts = 6;
    }

    // Start is called before the first frame update
    void Start()
    {
       

    }


    public void FailGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        hearts = 6;
        UpgradeLevel();
    }


    public void UpgradeLevel()
    {
        currentLevel = PlayerPrefs.GetInt("Level");

        if (!isHardLevel)
        {
            if (currentLevel >= 1 && currentLevel < 2)
            {
                
                ballCounts = 2;
                totalCircles = 2;

            }

            if (currentLevel >= 2 && currentLevel < 6)
            {
               
                ballCounts = 7;
                totalCircles = 3;
            }

            if (currentLevel >= 6 && currentLevel < 8)
            {
                ballCounts = 8;
                totalCircles = 5;
            }

            if (currentLevel >= 8 && currentLevel < 10)
            {
                ballCounts = 9;
                totalCircles = 7;
            }

            if (currentLevel >= 10 && currentLevel < 12)
            {
                ballCounts = 10;
                totalCircles = 9;
                rotateSpeed = 1.8f;
            }

            if (currentLevel >= 12 && currentLevel < 14)
            {
                ballCounts = 11;
                totalCircles = 11;
                rotateSpeed = 1.78f;
            }

            if (currentLevel >= 14 && currentLevel < 16)
            {
                ballCounts = 12;
                totalCircles = 13;
                rotateSpeed = 1.77f;
            }

            if (currentLevel >= 16 && currentLevel < 18)
            {
                ballCounts = 13;
                totalCircles = 15;
                rotateSpeed = 1.76f;
            }

            if (currentLevel >= 18 && currentLevel < 20)
            {
                ballCounts = 14;
                totalCircles = 16;
                rotateSpeed = 1.75f;
            }
            if (currentLevel == 20)
            {
                ballCounts = 24;
                totalCircles = 24;
                rotateSpeed = 1.5f;

            }
        }
        else
        {
            if (currentLevel >= 1 && currentLevel < 2)
            {
                ballCounts = 2;
                totalCircles = 2;

            }

            if (currentLevel >= 2 && currentLevel < 6)
            {
                ballCounts = 3;
                totalCircles = 2;
            }

            if (currentLevel >= 6 && currentLevel < 8)
            {
                ballCounts = 4;
                totalCircles = 2;
            }

            if (currentLevel >= 8 && currentLevel < 10)
            {
                ballCounts = 5;
                totalCircles = 2;
            }

            if (currentLevel >= 10 && currentLevel < 12)
            {
                ballCounts = 6;
                totalCircles = 3;
                rotateSpeed = 1.8f;
            }

            if (currentLevel >= 12 && currentLevel < 14)
            {
                ballCounts = 7;
                totalCircles = 4;
                rotateSpeed = 1.78f;
            }

            if (currentLevel >= 14 && currentLevel < 16)
            {
                ballCounts = 8;
                totalCircles = 5;
                rotateSpeed = 1.77f;
            }

            if (currentLevel >= 16 && currentLevel < 18)
            {
                ballCounts = 9;
                totalCircles = 5;
                rotateSpeed = 1.76f;
            }

            if (currentLevel >= 18 && currentLevel < 20)
            {
                ballCounts = 14;
                totalCircles = 16;
                rotateSpeed = 1.75f;
            }
            if (currentLevel == 20)
            {
                ballCounts = 24;
                totalCircles = 24;
                rotateSpeed = 1.5f;
            }
        }
    }


}
