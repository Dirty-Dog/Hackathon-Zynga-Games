using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonOnHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int bulletType;
    public GameObject Spawner;
    public bool isPressed,a = true;
    // Start is called before the first frame update
    void Start()
    {
        bulletType = 1;
    }

    // Update is called once per frame
    

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        Debug.Log("ispressedtrue");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    private void Update()
    {
        if (isPressed&a)
        {
            a = false;

            StartCoroutine(shoot());
        }
    }





    IEnumerator  shoot()
    {
       

        switch (bulletType)
        {
            case 3:
                GameObject bullet3 = Spawner.GetComponent<ObjectPool>().GetBullet3();
                if (bullet3 != null)
                {
                    
                    bullet3.transform.position = Spawner.transform.position;
                    bullet3.SetActive(true);
                    yield return new WaitForSeconds(0.2f);
                    a = true;
                }
                break;
            case 2:
                GameObject bullet2 = Spawner.GetComponent<ObjectPool>().GetBullet2();
                if (bullet2 != null)
                {
                    bullet2.transform.position = Spawner.transform.position;
                    bullet2.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    a = true;
                }
                break;
            case 1:
                GameObject bullet1 = Spawner.GetComponent<ObjectPool>().GetBullet1();
                if (bullet1 != null)
                {
                    
                    bullet1.transform.position = Spawner.transform.position;
                    bullet1.SetActive(true);
                    yield return new WaitForSeconds(0.3f);
                    a = true;
                    
                }
                break;
        }

        
    }
}
