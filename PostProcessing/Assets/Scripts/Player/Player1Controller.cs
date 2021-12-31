using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player1Controller : PlayerController
{
    [SerializeField] private Animator animPlayer;
    public GameObject colliderAttack;

    /// EVENTOS
    public static event Action onDeath;
    public static event Action <int> onHurt;

    void Start()
    {
        animPlayer.SetBool("isRun", false);
        
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
            }
            else{
                colliderAttack.SetActive(false);
            }
        }




    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifePlayer--;
            Destroy(collision.gameObject);
            Debug.Log("Dano recibido");
            onHurt?.Invoke(lifePlayer); 
            
            if (lifePlayer == 0)
            {
                onDeath?.Invoke(); 
            }

           
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
}
    

  