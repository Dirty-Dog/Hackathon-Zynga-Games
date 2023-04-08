using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public float speed;
    public GameObject gameManager;
    public GameManager gm;
    public int Type;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 0.01f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dodge")
        {
            gameObject.SetActive(false);

        }

        else if (other.gameObject.tag == "Player")
        {
            if (Type == 1)
            {
                gm.givePowerMultiLaser();
            }

            else if (Type == 2)
            {
                gm.givePowerSpreadDamage();
            }

            else if (Type == 3)
            {
                gm.ResetPowerups();
            }
            gameObject.SetActive(false);
        }
    }
}
