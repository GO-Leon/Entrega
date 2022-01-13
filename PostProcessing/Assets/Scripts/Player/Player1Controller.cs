using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player1Controller : PlayerController
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] private GameObject colliderAttack;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private float delayTime = 1.0f;



    /// EVENTOS
    public static event Action onDeath;
    public static event Action <int> onHurt;
    public static event Action onWeak;
    

    void Start()
    {
        animPlayer.SetBool("isRun", false);
        animPlayer.SetBool("isWeak", false);
       

    }

    public override void Update()
    {
        base.Update();
        if (pOne)
        {
            MovePlayer1();
            RotatePlayer();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Habilidad player 1");
                animPlayer.SetTrigger("Attack");
                colliderAttack.SetActive(true);
                Invoke("PlayAudio", delayTime);

            }
            else
            {
                colliderAttack.SetActive(false);
            }
          
        }
       }

    private void PlayAudio()
    {
        attackSound.Play();
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
                animPlayer.SetBool("isWeak", true);
            }

            if (lifePlayer == 0)
            {
                deathSound.Play();
                onDeath?.Invoke(); 
                animPlayer.SetTrigger("isP1Dead");
            }

           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            deathSound.Play();
            lifePlayer = 0;
            onDeath?.Invoke();
            
            animPlayer.SetTrigger("isP1Dead");
        }
    }



    protected void MovePlayer1()
    {
        float ejeVertical = Input.GetAxisRaw("Vertical");
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");

        if (ejeHorizontal != 0 || ejeVertical != 0)
        {
            animPlayer.SetBool("isRun", true);
            transform.Translate(pData.speedPlayer * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
        }
        else
        {
            animPlayer.SetBool("isRun", false);
        }
    }
// Agarrar armas
    public void ActivateWeapons(int numArma)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[numArma].SetActive(true);
    }

  
}
    

  