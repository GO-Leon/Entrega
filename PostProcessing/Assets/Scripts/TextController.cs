using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    [SerializeField] private Text coins;
    [SerializeField] private GameManager gm;
    
    [SerializeField] private TextMeshProUGUI coin;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        coin.text = ("x 0");

        
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = ("x " + GameManager.instance.totalCoins());
    }

      
}
