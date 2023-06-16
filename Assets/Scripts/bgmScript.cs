using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmScript : MonoBehaviour
{
   public static bgmScript instance;

   private void Awake()
   {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
   }
}
