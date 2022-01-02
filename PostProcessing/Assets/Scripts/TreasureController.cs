using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float wpSpeed;
    [SerializeField] float minDistance;
    [SerializeField] float rotationSpeed;
    private int currentIndex = 0;
    private bool goBack = false;
    // Start is called before the first frame update
    void Start()
    {
        WPMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


 private void WPMovement()
    {
        Vector3 deltaVector = waypoints[currentIndex].position - transform.position;
        Vector3 direction = deltaVector.normalized;
        transform.position += direction * wpSpeed * Time.deltaTime;
        float distance = deltaVector.magnitude;

        if(distance < minDistance)
        {
            if(currentIndex >= waypoints.Length - 1)
            {
                goBack = true;
            }
            else if (currentIndex <= 0)
            {
                goBack = false;
            }
            if (!goBack)
            {
                currentIndex++;
            }
            else currentIndex--;
        }
    }
}