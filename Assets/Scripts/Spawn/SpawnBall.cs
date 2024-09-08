using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 positionSpawn;

    [SerializeField]
    Vector3 positionSpawnInHardLevel;

    [SerializeField]
    Vector3 direction;

    public GameObject Spawn()
    {
        if(LevelHandler.Instance.isHardLevel)
        {
            GameObject newBall = Instantiate<GameObject>(prefab, positionSpawnInHardLevel, Quaternion.identity);
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
            return newBall;
        } else
        {
            GameObject newBall = Instantiate<GameObject>(prefab, positionSpawn, Quaternion.identity);
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
            return newBall;
        }
        
        

    }
}
