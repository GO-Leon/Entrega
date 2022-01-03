using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] float collisionTH = 1f;
    private float collisionTime = 5f;
    [SerializeField] private ParticleSystem breakParticle;
    [SerializeField] private AudioSource glassSound;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        breakParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        collisionTime += Time.deltaTime;
        if (collisionTH < collisionTime && collisionTime < 3f)
        {
            
            Destroy(gameObject);
            breakParticle.Play();
                     
        }
        
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            
            collisionTime = 0.0f;
            Debug.Log("Atacaste la pared");
            breakParticle.Stop();

            glassSound.Play();

        }
    }


  

        
}

        

    

   
