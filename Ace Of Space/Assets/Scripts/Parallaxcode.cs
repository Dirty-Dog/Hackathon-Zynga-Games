using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxcode : MonoBehaviour
{
    Material mat;
    float distance;
    public GameManager gm;

    [Range(0f, 0.5f)]

    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed;

        mat.SetTextureOffset("_MainTex", Vector2.up * distance);
    }

    public void IncreaseDifficulty()
    {
        if (gm.Difficulty > 9)
        {
            speed = 0.08f;
        }
        else if (gm.Difficulty > 7)
        {
            speed = 0.07f;
        }
        else if (gm.Difficulty > 5)
        {
            speed = 0.06f;
        }
        else if (gm.Difficulty > 2)
        {
            speed = 0.05f;
        }
    }
}
