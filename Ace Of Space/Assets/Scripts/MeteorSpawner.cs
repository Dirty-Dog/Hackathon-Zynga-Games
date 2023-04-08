using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject gameManager;
    public GameManager gm;
    public float waitTime = 1.8f;

    public GameObject Spawner, metSpawner;
    public bool a = true;


    public float Po1, Po2, Po3;


    void Start() 
    {
        
        gm = gameManager.GetComponent<GameManager>();
        Po1 = 8;
        Po2 = 3;
        Po3 = 0;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            a = false;

            StartCoroutine(CalculateRandomness());
            
        }
        IncreaseDifficulty();
    }

    public IEnumerator CalculateRandomness()
    {
        float x = Random.Range(0, 10);

        if( x < Po1)
        {
            GameObject meteor1 = Spawner.GetComponent<ObjectPool>().GetMeteor1();
            if (meteor1 != null)
            {
                meteor1.transform.position = metSpawner.transform.position;
                meteor1.SetActive(true);
                
            }
        }
        else if(x < Po2)
        {
            GameObject meteor2 = Spawner.GetComponent<ObjectPool>().GetMeteor2();
            if (meteor2 != null)
            {
                meteor2.transform.position = metSpawner.transform.position;
                meteor2.SetActive(true);
                
            }
        }
        else if(x < Po3)
        {
            GameObject meteor3 = Spawner.GetComponent<ObjectPool>().GetMeteor3();
            if (meteor3 != null)
            {
                meteor3.transform.position = metSpawner.transform.position;
                meteor3.SetActive(true);
                
            }
        }
        else
        {
            GameObject meteor1 = Spawner.GetComponent<ObjectPool>().GetMeteor1();
            if (meteor1 != null)
            {
                meteor1.transform.position = metSpawner.transform.position;
                meteor1.SetActive(true);

            }
        }

        yield return new WaitForSeconds(waitTime);
        //a = true;
    }

    public void IncreaseDifficulty()
    {
        if(gm.Difficulty > 9)
        {
            Po1 = 2;
            Po2 = 3;
            Po3 = 9;
            waitTime = 0.8f;
        }
        else if (gm.Difficulty > 7)
        {
            Po1 = 1;
            Po2 = 3;
            Po3 = 8;
            waitTime = 1.1f;
        }
        else if (gm.Difficulty > 5)
        {
            Po1 = 5;
            Po2 = 7;
            Po3 = 5;
            waitTime = 1.4f;
        }
        else if (gm.Difficulty > 2)
        {
            Po1 = 6;
            Po2 = 7;
            Po3 = 4;
            waitTime = 1.6f;
        }
    }
}
