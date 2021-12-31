using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] float collisionTH = 1f;
    private float collisionTime = 5f;
    [SerializeField] private ParticleSystem breakParticle;

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
        }
    }
/*
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Axe")))
        {
            collisionTime = 0.0f;
            Debug.Log("colision");
            breakParticle.Stop();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Axe")))
        {
            collisionTime = 5.0f;
            breakParticle.Stop();
        }
    }
    */
}
