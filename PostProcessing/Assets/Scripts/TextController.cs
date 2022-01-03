using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    [SerializeField] private Text coins;
    [SerializeField] private GameManager gm;
    [SerializeField] private TextMeshProUGUI textLivesP1;
    [SerializeField] private TextMeshProUGUI textLivesP2;
    [SerializeField] private TextMeshProUGUI coin;
    [SerializeField] private GameObject youWin;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        coin.text = ("x 0");
        Player1Controller.onHurt += OnHurtHandlerP1;
        Player2Controller.onHurt += OnHurtHandlerP2;
        Player1Controller.onDeath += OnDeathHandler;
        Player2Controller.onDeath += OnDeathHandler;
        youWin.SetActive(false);


    }

    private void OnDeathHandler()
    {
        textLivesP1.text = "GAME OVER";
        textLivesP2.text = "GAME OVER";

    }

    private void OnHurtHandlerP1(int lives)
    {
        textLivesP1.text = "Brute : " + lives;
    }

    private void OnHurtHandlerP2(int lives)
    {
        textLivesP2.text = "Jumper : " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = ("x " + GameManager.instance.totalCoins());

        if (GameManager.instance.totalCoins() == 10)
        {
            youWin.SetActive(true);
        }

    }

      
}
