using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ObjectToPool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
