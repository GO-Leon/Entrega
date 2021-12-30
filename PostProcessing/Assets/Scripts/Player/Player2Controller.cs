using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player2Controller : PlayerController
{
    [SerializeField] private Animator animPlayer2;
    private Rigidbody rb;

    /// EVENTOS
    public static event Action onDeath;

    void Start()
    {
        animPlayer2.SetBool("isRun2", false);
        rb = GetComponent<Rigidbody>();

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
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //Destroy(collision.gameObject);
            Debug.Log("Daño recibido");
            onDeath?.Invoke();

        }


    }
}
