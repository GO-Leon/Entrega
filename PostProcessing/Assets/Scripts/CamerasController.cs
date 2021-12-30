using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras;
    [SerializeField] private List<GameObject> airCamerasP1;
    [SerializeField] private List<GameObject> airCamerasP2;    
    [SerializeField] private int indexCameraP1 = 0; 
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
                
            }
            else
            {
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);
            }
        }


        if (Input.GetKeyDown(KeyCode.Tab) && pOne)
        {
            indexCameraP1++;
            if(indexCameraP1 == airCamerasP1.Count)
            {
                indexCameraP1 = 0;
            }
            ChangeAirCameraP1(indexCameraP1);
        }
        if (Input.GetKeyDown(KeyCode.P) && pOne)
        {
            --indexCameraP1;
            if(indexCameraP1 == airCamerasP1.Count)
            {
                indexCameraP1 = 0;
            }
            if(indexCameraP1 < 0)
            {
                indexCameraP1 = 2;
            }
            ChangeAirCameraP1(indexCameraP1);
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
    void ChangeAirCameraP1(int index)
    {
        foreach (var camera in airCamerasP1)
        {
            camera.SetActive(false);
        }
        airCamerasP1[index].SetActive(true);
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

