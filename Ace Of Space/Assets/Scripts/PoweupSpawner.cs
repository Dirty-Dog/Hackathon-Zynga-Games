using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweupSpawner : MonoBehaviour
{

    public GameObject[] powerups;
    public float checker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        checker += Time.deltaTime;
        if(checker >= 100)
        {
            spawnPowerup();
            checker = 0;
        }


    }

    void spawnPowerup()
    {
        Instantiate(powerups[Random.Range(0,3)],gameObject.transform.position, Quaternion.identity);
    }
}
