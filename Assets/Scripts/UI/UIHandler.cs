using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform heartSpace;

    [SerializeField]
    private RectTransform ballCountsSpace;

    [SerializeField]
    GameObject BallCountPrefab;

    [SerializeField]
    GameObject HeartPrefab;

    [SerializeField]
    List<GameObject> listOfBallCountUI;
    [SerializeField]
    List<GameObject> listOfHeartUI;


    // Start is called before the first frame update
    void Start()
    {
        InitBallCountUI(LevelHandler.Instance.ballCounts);
        InitHeartUI(LevelHandler.Instance.hearts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitBallCountUI(int size)
    {
        listOfBallCountUI = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject ball = Instantiate(BallCountPrefab, Vector3.zero, Quaternion.identity);
            ball.transform.SetParent(ballCountsSpace);
            listOfBallCountUI.Add(ball);
        }
    }

    private void InitHeartUI(int size)
    {
        listOfHeartUI = new List<GameObject>();
        for(int i = 0; i < size; i++)
        {
            GameObject heart = Instantiate(HeartPrefab, Vector3.zero, Quaternion.identity);
            heart.transform.SetParent(heartSpace);
            listOfHeartUI.Add(heart);
        }
    }
}
