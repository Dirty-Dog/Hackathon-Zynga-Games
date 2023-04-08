using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Health;
    
    public int CurrentScore;
    public int HighScore;
    [Range(0.0f, 10.0f)]
    public float Difficulty;
    [Range(2.0f, 10.0f)]
    public float currentMaxDifficultyLevel;

    private float secondsCount;
    public int distance;
    public ButtonOnHold Shooter;
    public float waitTime;


    float tempDistance;



    public GameObject[] Spawners;
    public GameObject shield, life1, life2, life3;
    bool a = true;


    public TextMeshProUGUI textmeshPro;







    // Start is called before the first frame update
    void Start()
    {
        waitTime = 1.8f;
        Difficulty = 1;
        CurrentScore = 0;
        tempDistance = 0;
        foreach (GameObject spawner in Spawners)
        {
            spawner.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        setPlayerHealth();

        IncreaseDifficulty();
        secondsCount += Time.deltaTime;
        distance = (int)secondsCount * (int)Difficulty;
        tempDistance += distance;
        if (tempDistance <= 40)
        {
            setDiffuclutyLevel(2);
            tempDistance = 0;
        }

        if (Difficulty < currentMaxDifficultyLevel)
        {
            Difficulty += 0.05f * Time.deltaTime;
        }

        string temmpscore = distance.ToString();
        textmeshPro.text = temmpscore;

        if (a)
        {
            a = false;
            StartCoroutine(RandomSpawner());
        }
    }

    IEnumerator RandomSpawner()
    {
        int x = Random.Range(0, Spawners.Length);
        int y = Random.Range(0, Spawners.Length);
        int z = Random.Range(0, Spawners.Length);
        while (x == y)
        {
            y = Random.Range(0, Spawners.Length);
        }
        while (z == y)
        {
            y = Random.Range(0, Spawners.Length);
        }
        while (x == z)
        {
            z = Random.Range(0, Spawners.Length);
        }
        Spawners[x].SetActive(true);
        Spawners[y].SetActive(true);
        if (Difficulty > 7)
            Spawners[z].SetActive(true);

        yield return new WaitForSeconds(waitTime);
        Spawners[x].GetComponent<MeteorSpawner>().a = true;
        Spawners[y].GetComponent<MeteorSpawner>().a = true;
        if (Difficulty > 7)
            Spawners[z].GetComponent<MeteorSpawner>().a = true;

        yield return new WaitForSeconds(waitTime);

        Spawners[x].SetActive(false);
        Spawners[y].SetActive(false);
        if (Difficulty > 7)
            Spawners[z].SetActive(false);

        a = true;

    }

    public void addScore(int scoreToAdd)
    {
        CurrentScore += scoreToAdd;
    }

    public void reduceHealth()
    {
        Health -= 1;
    }

    public void givePowerMultiLaser()
    {
        Shooter.bulletType = 2;
        Invoke("ResetPowerups", 5.0f);
    }

    public void givePowerSpreadDamage()
    {
        Shooter.bulletType = 3;
        Invoke("ResetPowerups", 5.0f);
    }

    public void givePowerForceField()
    {
        shield.SetActive(true);
        Invoke("ResetPowerups", 5.0f);
    }

    public void ResetPowerups()
    {
        Shooter.bulletType = 1;
        shield.SetActive(false);
    }

    public void setDiffuclutyLevel(int DL)
    {
        currentMaxDifficultyLevel += DL;
    }

    public void IncreaseDifficulty()
    {
        if (Difficulty > 9)
        {
            waitTime = 0.6f;
        }
        else if (Difficulty > 7)
        {
            waitTime = 0.75f;
        }
        else if (Difficulty > 5)
        {
            waitTime = 0.9f;
        }
        else if (Difficulty > 2)
        {
            waitTime = 1.1f;
        }
    }

    public void setPlayerHealth()
    {
        if(Health == 2)
        {
            life3.SetActive(false);      
        }
        else if ( Health == 1)
        {
            life2.SetActive(false);
        }
        else if (Health == 0)
        {
            life1.SetActive(false);
            Invoke("gameOver", 0.5f);
        }
    }   

    public void gameOver()
    {
        SceneManager.LoadScene(1);
    }
}
