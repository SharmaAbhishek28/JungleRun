using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME_OVER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}