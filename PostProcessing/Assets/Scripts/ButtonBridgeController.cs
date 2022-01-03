using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ButtonBridgeController : MonoBehaviour
{
    [SerializeField] private UnityEvent onActiveBridge;
    [SerializeField] private AudioSource bridgeSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            onActiveBridge.Invoke();
            bridgeSound.Play();
        }
    }
}
