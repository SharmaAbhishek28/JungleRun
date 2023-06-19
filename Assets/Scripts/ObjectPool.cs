using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstace;
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    public int AmountToPool;
    // Start is called before the first frame update
    private void Awake()
    {
        SharedInstace =  this;
    }

    void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject tmp;



        for (int i = 0; i < AmountToPool; i++)
        {
           tmp = Instantiate(ObjectToPool);    
           tmp.SetActive(false);
           PooledObjects.Add(tmp);
        }
        
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < AmountToPool; i++)
        {
            if(!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        return null;
    }
}
