using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    [SerializeField]
    private Color[] color1;

    [SerializeField]
    private Color[] color2;

    [SerializeField]
    private Color[] color3;

    public Color[] currentColorArray { get; private set; }

    private void OnEnable()
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        int randomC = Random.Range(0, 2);

        if (randomC == 0)
            currentColorArray = color1;

        if (randomC == 1)
            currentColorArray = color2;

        if (randomC == 2)
            currentColorArray = color3;
    }
}
