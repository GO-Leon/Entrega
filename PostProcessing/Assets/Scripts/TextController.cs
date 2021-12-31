using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    [SerializeField] private Text coins;
    [SerializeField] private GameManager gm;
    [SerializeField] private TextMeshProUGUI textLives;
    [SerializeField] private TextMeshProUGUI coin;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        coin.text = ("x 0");
        Player1Controller.onHurt += OnHurtHandler;
        Player2Controller.onHurt += OnHurtHandler;
        Player1Controller.onDeath += OnDeathHandler;
        Player2Controller.onDeath += OnDeathHandler;

        
    }

    private void OnDeathHandler()
    {
        textLives.text = "GAME OVER";
    }

    private void OnHurtHandler(int lives)
    {
        textLives.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = ("x " + GameManager.instance.totalCoins());
    }

      
}
