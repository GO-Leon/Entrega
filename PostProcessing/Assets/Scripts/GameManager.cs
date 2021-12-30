using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int coinsInstance;
    public enum itemType { Martillo, Escudo};   

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            coinsInstance = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
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
}
