using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
    private int coinsInstance;
    public enum itemType { Martillo, Escudo};

  
            private void Awake()
    {

                if (instance == null)
                {
                    //First run, set the instance
                    instance = this;
                    DontDestroyOnLoad(gameObject);

                }
                else if (instance != this)
                {
                    //Instance is not the same as the one we have, destroy old one, and reset to newest one
                    Destroy(instance.gameObject);
                    instance = this;
                    DontDestroyOnLoad(gameObject);

                }
                // DontDestroyOnLoad(gameOverScreen);
            }
    void Start()
    {
        Player1Controller.onDeath += GameOver;
        Player2Controller.onDeath += GameOver;
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addCoins()
    {
        instance.coinsInstance += 1;
    }
    public int totalCoins()
    {
        return instance.coinsInstance;
    }
    private void GameOver()
    {
       
        Debug.Log("perdiste");
        //gameOverScreen.SetActive(true);
    }
}
