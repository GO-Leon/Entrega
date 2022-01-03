using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Vector3.forward * Time.deltaTime * speedCoinRotation;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.contacts[0].otherCollider.gameObject.CompareTag("Player1")) || (collision.contacts[0].otherCollider.gameObject.CompareTag("Player2")))
        {
            audioSource.Play();
            GameManager.instance.addCoins();                
            Debug.Log(GameManager.instance.totalCoins());
            Destroy(gameObject);
        }
    }



}
