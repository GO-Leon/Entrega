using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject showingObject;
    [SerializeField] private AudioSource bridgeSound;

    // Start is called before the first frame update
    void Start()
    {
        showingObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player2")))
        {
            showingObject.SetActive(true);
            Debug.Log("Puente activado");
            bridgeSound.Play();

        }
       
    }
    public void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Player2")))
        {
            showingObject.SetActive(false);
            Debug.Log("Puente desactivado");
        }
    }



}
