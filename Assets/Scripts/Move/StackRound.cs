using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackRound : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float unitToMoveY;
    
    public void Stack(GameObject obj)
    {
        obj.transform.DOMoveY(unitToMoveY, speed).SetEase(Ease.OutElastic).SetRelative();
    }

}
