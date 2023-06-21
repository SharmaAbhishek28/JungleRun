using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectRotate : MonoBehaviour
{
    
    public int rotateSpeed = 1;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag=="player")
        {
            PlayerMovement.score+=1;
            
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

}
