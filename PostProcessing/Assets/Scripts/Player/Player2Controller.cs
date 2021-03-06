using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player2Controller : PlayerController
{
    [SerializeField] private Animator animPlayer2;
    private Rigidbody rb;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource hurtSound;

    /// EVENTOS
    public static event Action onDeath;
    public static event Action <int> onHurt;
    public static event Action onWeak;

    void Start()
    {
        animPlayer2.SetBool("isRun2", false);
        rb = GetComponent<Rigidbody>();
        Debug.Log("Utiliza el tercer ojo de Jumper para planificar la estrategia presionando Tab / P");

    }

    public override void Update()
    {
        base.Update();
        if (!pOne)
        {
            MovePlayer2();
            RotatePlayer();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (floorContact)
                {
                    Jump();
                    animPlayer2.SetTrigger("Jump");
                    jumpSound.Play();

                }
            }
        }




    }


    protected void MovePlayer2()
    {
        float ejeVertical = Input.GetAxisRaw("Vertical");
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");

        if (ejeHorizontal != 0 || ejeVertical != 0)
        {
            animPlayer2.SetBool("isRun2", true);
            transform.Translate(pData.speedPlayer * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
        }
        else
        {
            animPlayer2.SetBool("isRun2", false);
        }
    }

    protected void Jump()
    {
        Debug.Log(pData.playerName + " salto");
        rb.AddForce(0, 1 * pData.jumpForce, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifePlayer--;
            Destroy(collision.gameObject);
            Debug.Log("Dano recibido");
            onHurt?.Invoke(lifePlayer);
            hurtSound.Play();


            if (lifePlayer == 1)
            {
                onWeak?.Invoke();
                animPlayer2.SetBool("isWeak2", true);
            }

            if (lifePlayer == 0)
            {
                deathSound.Play();
                onDeath?.Invoke(); 
                animPlayer2.SetTrigger("isP2Dead");
            }

           
        }
        
        if (collision.gameObject.CompareTag("Water"))
        {
            deathSound.Play();
            lifePlayer = 0;
            onDeath?.Invoke(); 
            animPlayer2.SetTrigger("isP2Dead");
           
        }
    }
    

}
