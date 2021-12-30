using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// probando 

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject showingObject;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("on");

        }
       
    }
    public void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Player2")))
        {
            showingObject.SetActive(false);
            Debug.Log("off");
        }
    }



}
