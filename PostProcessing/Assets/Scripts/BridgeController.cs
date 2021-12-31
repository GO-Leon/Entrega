using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] GameObject showingBridge;
    [SerializeField] GameObject showingWall;
    // Start is called before the first frame update
    void Start()
    {

        showingBridge.SetActive(false);
        showingWall.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBridge()
    {
        showingBridge.SetActive(true);
        showingWall.SetActive(false);
        Debug.Log("Puente activado");
        Debug.Log("Pared destruida");

    }
}
