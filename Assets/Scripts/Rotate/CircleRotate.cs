using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleRotate : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    bool isLinear;

    [SerializeField]
    bool isYoyo;

    Tween tween;

   
    // Start is called before the first frame update
    void Start()
    {
        InitRotate();

    }

    private void InitRotate()
    {
        if (isLinear)
        {
            tween = transform.DORotate(new Vector3(0, 360, 0), rotateSpeed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
        if (isYoyo)
        {
            tween = transform.DORotate(new Vector3(0, 360, 0), rotateSpeed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }

    public void StopRotate()
    {
        tween.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
