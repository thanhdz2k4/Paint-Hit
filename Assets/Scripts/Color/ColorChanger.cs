using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    BallHandler ballHandler;

    ColorHandler colorHandler;
    // Start is called before the first frame update
    void Start()
    {
        ballHandler = FindAnyObjectByType<BallHandler>();
        colorHandler = FindAnyObjectByType<ColorHandler>();

        gameObject.GetComponent<MeshRenderer>().material.color = colorHandler.currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "red")
        {
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            UIHandler uIHandler = FindAnyObjectByType<UIHandler>();
            uIHandler.UpdateHeartUI();
            if(uIHandler != null)
            {
                Debug.Log("uihandler != null");
            }
            LevelHandler.Instance.MinusHeart();
            Destroy(base.gameObject);
            print("game over");
            

        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = true;
            collision.gameObject.name = "color";
            collision.gameObject.tag = "red";
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = colorHandler.currentColor;
            Destroy(base.gameObject);
        }


    }
}
