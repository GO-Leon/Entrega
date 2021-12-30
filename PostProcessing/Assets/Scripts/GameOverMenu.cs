using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    
    void Awake()
    {
        Player1Controller.onDeath += GameOver;
        Player2Controller.onDeath += GameOver;
        gameObject.SetActive(false);

        
    }
    public void PlayGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     


    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameObject.SetActive(true);

        
    }
}
