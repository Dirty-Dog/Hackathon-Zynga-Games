using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Touch touch;
    private float moveSpeed, minStick;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 3f;
        minStick = 1.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }


    public void move()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > 0 + minStick)
                {
                    rb.velocity = Vector2.right * moveSpeed;                  
                }

                else if (touch.deltaPosition.x < 0 - minStick)
                {
                    rb.velocity = -Vector2.right * moveSpeed;
                }


            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}