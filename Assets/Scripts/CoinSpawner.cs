using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndPos;

    private float Current_Coin_Position;
    // Start is called before the first frame update
    void Start()
    {
        Current_Coin_Position = StartPos.position.z;
        while (Current_Coin_Position < EndPos.position.z)
        {
            GameObject Coin = ObjectPool.SharedInstance.GetPooledObject();
            if (Coin != null)
            {
               Coin.transform.position = new Vector3(StartPos.position.x, StartPos.position.y,Current_Coin_Position);
               Coin.SetActive(true);
            }
            Current_Coin_Position++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
