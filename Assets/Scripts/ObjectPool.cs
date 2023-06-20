using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    public int  AmountToPool;
    

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject tmp;


        for (int i = 0; i < 11; i++)
        {
           tmp = Instantiate(ObjectToPool);
           tmp.SetActive(false);
           PooledObjects.Add(tmp);
        }
        
    }

   public GameObject GetPooledObject()
   {
        for(int i = 0; i < 11; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        return null;
   }
}