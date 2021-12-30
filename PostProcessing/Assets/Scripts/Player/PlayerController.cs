using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected PlayerData pData;
    [SerializeField] protected bool pOne = true;
    float cameraAxis;
    //[SerializeField] private int lifePlayer = 1;
    //[SerializeField] private Animator animPlayer;
    //[SerializeField] private string namePlayer = "Capsule";
    //[SerializeField] protected float speedPlayer = 4.0f;
    //[SerializeField]    private float jumpForce;
    public bool floorContact = true;
    // Start is called before the first frame update


  
    /// 

    void Start()
    {
        
    }
    
   

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pOne = !pOne;
        }


              
    }


    protected void Move()
    {
        float ejeVertical = Input.GetAxisRaw("Vertical");
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(pData.speedPlayer * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
        
    }

    protected void RotatePlayer()
    {
        cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angle = Quaternion.Euler(0, cameraAxis + 180, 0);
        transform.localRotation = angle;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            floorContact = true;
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            
            Debug.Log("ondeath");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            floorContact = false;

        }
    }
    
}
