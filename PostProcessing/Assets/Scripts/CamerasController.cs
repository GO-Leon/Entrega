using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras;
    [SerializeField] private List<GameObject> airCamerasP2;    
    [SerializeField] private int indexCameraP2 = 0; 
    [SerializeField] bool pOne = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pOne = !pOne;
        }
      
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pOne)
            { 
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);
                transform.position = cameras[0].transform.position;


            }
            else
            {
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);
                transform.position = cameras[1].transform.position;
            }
        }


        if (Input.GetKeyDown(KeyCode.Tab) && !pOne)
        {
            indexCameraP2++;
            if(indexCameraP2 == airCamerasP2.Count)
            {
                indexCameraP2 = 0;
            }
            ChangeAirCameraP2(indexCameraP2);
        }
        if (Input.GetKeyDown(KeyCode.P) && !pOne)
        {
            --indexCameraP2;
            if(indexCameraP2 == airCamerasP2.Count)
            {
                indexCameraP2 = 0;
            }
            if(indexCameraP2 < 0)
            {
                indexCameraP2 = 2;
            }
            ChangeAirCameraP2(indexCameraP2);
        }
    }
   
    void ChangeAirCameraP2(int index)
    {
        foreach (var camera2 in airCamerasP2)
        {
            camera2.SetActive(false);
        }
        airCamerasP2[index].SetActive(true);
    }
}

