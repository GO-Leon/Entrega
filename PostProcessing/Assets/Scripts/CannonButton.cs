using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CannonButton : MonoBehaviour
{
    [SerializeField] private UnityEvent onDesctiveCannons;
    [SerializeField] private ParticleSystem cannonsParticle1;
    [SerializeField] private ParticleSystem cannonsParticle2;
    [SerializeField] private ParticleSystem cannonsParticle3;
    [SerializeField] private ParticleSystem cannonsParticle4;
    [SerializeField] private AudioSource bridgeSound;



    void Start()
    {
            cannonsParticle1.Stop();
            cannonsParticle2.Stop();
            cannonsParticle3.Stop();
            cannonsParticle4.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            onDesctiveCannons?.Invoke();
            cannonsParticle1.Play();
            cannonsParticle2.Play();
            cannonsParticle3.Play();
            cannonsParticle4.Play();
            Debug.Log("Explosivos activados");
            bridgeSound.Play();
        }
    }

        public void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Player2")))
        {
            cannonsParticle1.Stop();
            cannonsParticle2.Stop();
            cannonsParticle3.Stop();
            cannonsParticle4.Stop();
        }
    }
}
