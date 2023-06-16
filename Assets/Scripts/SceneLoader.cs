using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void PageNavigation(int SceneIndex)
   {
    SceneManager.LoadScene(SceneIndex);
   }
   void Update(){
      if (Application.platform == RuntimePlatform.Android)
      {
         if (Input.GetKeyDown(KeyCode.Escape))
         {
            int previousSceneIndex=SceneManager.GetActiveScene().buildIndex-1;
            SceneManager.LoadScene(previousSceneIndex);      
         }
      }
   }
}
