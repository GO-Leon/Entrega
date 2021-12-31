using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1PowerUps : MonoBehaviour
{
    private InventoryManager p1Inventory;
    public Player1Controller grabWeapons;
    public int weaponsNumber;

    // Start is called before the first frame update
    void Start()
    {
        p1Inventory = GetComponent<InventoryManager>();
        grabWeapons = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UsePowerUp();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("Agarraste el martillo, ahora podes romper muros");
            GameObject powerUp = other.gameObject;
            powerUp.SetActive(false);
           p1Inventory.AddInventoryPOne(powerUp);
            grabWeapons.ActivateWeapons(weaponsNumber);

        }
    }

    private void UsePowerUp()
    {
        GameObject powerUp = p1Inventory.GetInventoryPOne();
        powerUp.SetActive(true);
        powerUp.transform.position = transform.position + new Vector3(0f,1f,-5f);
    }
}
