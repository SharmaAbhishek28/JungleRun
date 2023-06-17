using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOneControl : MonoBehaviour
{
    private void update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            Application.Quit();
            else 
                SceneManager.LoadScene(0);
        }
    }
}
