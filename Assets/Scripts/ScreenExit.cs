using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenExit : MonoBehaviour
{
 public void QuitGame()  
 {
    Application.Quit();
    Debug.Log("Quit!");
 }
}