using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonWaterController : MonoBehaviour
{
    [SerializeField] private UnityEvent onDestroyEnemy;
    [SerializeField] private ParticleSystem woodParticle;
    [SerializeField] private AudioSource bridgeSound;



    void Start()
    {
            woodParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            onDestroyEnemy?.Invoke();
            woodParticle.Play();
            Debug.Log("Explosivos activados");
            bridgeSound.Play();
        }
    }

        public void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Player2")))
        {
            woodParticle.Stop();
        }
    }
}
