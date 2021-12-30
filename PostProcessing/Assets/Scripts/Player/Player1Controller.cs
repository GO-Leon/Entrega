using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerController
{
    [SerializeField] private Animator animPlayer;

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
                Debug.Log("  habilidad player 1 ");
                animPlayer.SetTrigger("Attack");
            }
        }




    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Daño recibido");
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
    

  