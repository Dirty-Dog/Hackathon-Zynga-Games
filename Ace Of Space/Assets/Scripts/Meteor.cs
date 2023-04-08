using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour
{
    public float speed;
    public GameManager gm;
    public int Type;
    public int Health;
    public int tempHealth;
    

    public float MaxSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        tempHealth = Health;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        IncreaseDifficulty();
        transform.Translate(Vector2.down * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Dodge")
        {
            gm.addScore(5);
            Health = 0;

        }

        else if (other.gameObject.tag == "Bullet")
        {
            
            if (Type == 1)
            {
                gm.addScore(10);
            }
            else if (Type == 2)
            {
                gm.addScore(10);
            }
            else if (Type == 3)
            {
                gm.addScore(20);
            }
            Health--;
        }

        else if (other.gameObject.tag == "Player")
        {
            gm.reduceHealth();
            Health = 0;
        }

        else if (other.gameObject.tag == "Shield")
        {
            Health = 0;
        }



        if (Health <=0)
        {
            Health = tempHealth;
            gameObject.SetActive(false);
        }
            
    }


    public void IncreaseDifficulty()
    {
        if (gm.Difficulty > 9)
        {
            speed = MaxSpeed;
        }
        else if (gm.Difficulty > 7)
        {
            speed = 0.02f ;
        }
        else if (gm.Difficulty > 5)
        {
            speed = 0.015f ;
        }
        else if (gm.Difficulty > 2)
        {
            speed = 0.013f ;
        }
    }
}
