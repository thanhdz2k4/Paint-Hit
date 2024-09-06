using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundUI : MonoBehaviour
{
    [SerializeField] Image BG;

    [SerializeField] Sprite[] spr;

    [SerializeField] GameObject pauseScreen;

    void Start()
    {
        NewBG();
    }

    public void NewBG()
    {
        BG.sprite = spr[Random.Range(0, 4)];
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
