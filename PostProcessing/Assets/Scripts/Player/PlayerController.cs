using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected PlayerData pData;
    [SerializeField] protected bool pOne = true;
    float cameraAxis;
    public int lifePlayer = 3;
    public bool floorContact = true;


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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            floorContact = false;

        }
    }
    
}
