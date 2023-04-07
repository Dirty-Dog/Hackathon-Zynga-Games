using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private List<GameObject> PooledObjectT1 = new List<GameObject>();
    private List<GameObject> PooledObjectT2 = new List<GameObject>();
    private List<GameObject> PooledObjectT3 = new List<GameObject>();
    int amountToPool = 20;

    [SerializeField] private GameObject bulletType1;
    [SerializeField] private GameObject bulletType2;
    [SerializeField] private GameObject bulletType3;


    private List<GameObject> PooledObjectM1 = new List<GameObject>();
    private List<GameObject> PooledObjectM2 = new List<GameObject>();
    private List<GameObject> PooledObjectM3 = new List<GameObject>();
    int amountToPoolM =15;

    [SerializeField] private GameObject MeteorType1;
    [SerializeField] private GameObject MeteorType2;
    [SerializeField] private GameObject MeteorType3;


    private void awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletType1);
            obj.SetActive(false);
            PooledObjectT1.Add(obj);

            GameObject obj1 = Instantiate(bulletType2);
            obj1.SetActive(false);
            PooledObjectT2.Add(obj1);

            GameObject obj2 = Instantiate(bulletType3);
            obj2.SetActive(false);
            PooledObjectT3.Add(obj2);
        }

        for (int i = 0; i < amountToPoolM; i++)
        {
            GameObject obj = Instantiate(MeteorType1);
            obj.SetActive(false);
            PooledObjectM1.Add(obj);

            GameObject obj1 = Instantiate(MeteorType2);
            obj1.SetActive(false);
            PooledObjectM2.Add(obj1);

            GameObject obj2 = Instantiate(MeteorType3);
            obj2.SetActive(false);
            PooledObjectM3.Add(obj2);
        }
    }

    public GameObject GetBullet1()
    {
        
        for (int i = 0; i < PooledObjectT1.Count; i++)
        {
            if (!PooledObjectT1[i].activeInHierarchy)
            {
                return PooledObjectT1[i];
            }
        }

        return null;
    }


    public GameObject GetBullet2()
    {
        for (int i = 0; i < PooledObjectT2.Count; i++)
        {
            if (!PooledObjectT2[i].activeInHierarchy)
            {
                return PooledObjectT2[i];
            }
        }

        return null;
    }


    public GameObject GetBullet3()
    {
        for (int i = 0; i < PooledObjectT3.Count; i++)
        {
            if (!PooledObjectT3[i].activeInHierarchy)
            {
                return PooledObjectT3[i];
            }
        }

        return null;
    }


    public GameObject GetMeteor1()
    {

        for (int i = 0; i < PooledObjectM1.Count; i++)
        {
            if (!PooledObjectM1[i].activeInHierarchy)
            {
                return PooledObjectM1[i];
            }
        }

        return null;
    }

    public GameObject GetMeteor2()
    {

        for (int i = 0; i < PooledObjectM2.Count; i++)
        {
            if (!PooledObjectM2[i].activeInHierarchy)
            {
                return PooledObjectM2[i];
            }
        }

        return null;
    }


    public GameObject GetMeteor3()
    {

        for (int i = 0; i < PooledObjectM3.Count; i++)
        {
            if (!PooledObjectM3[i].activeInHierarchy)
            {
                return PooledObjectM3[i];
            }
        }

        return null;
    }

}
