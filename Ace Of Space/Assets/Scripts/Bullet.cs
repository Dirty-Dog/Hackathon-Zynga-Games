using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ public float speed;
  
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.up * speed); 
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Dodge" || other.gameObject.tag == "Meteor")
        {
            gameObject.SetActive(false);

        }

    }
}
