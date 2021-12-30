using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuit : MonoBehaviour
{
     [SerializeField] private float pursuitRay = 20f;
     [SerializeField] private GameObject pursuitPoint;
     [SerializeField] private GameObject player;
     [SerializeField] private float speedEnemy = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastPursuit();
    }

        private void RaycastPursuit()
    {
        RaycastHit hitPursuit;
       if (Physics.Raycast(pursuitPoint.transform.position, pursuitPoint.transform.TransformDirection(Vector3.forward), out hitPursuit, pursuitRay))
       {
           Debug.Log("Perseguir Player");
           Vector3 direction = player.transform.position - transform.position;
           transform.position += speedEnemy * direction * Time.deltaTime;
       }
    }
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawRay(pursuitPoint.transform.position, pursuitPoint.transform.TransformDirection(Vector3.forward) * pursuitRay);
    }
}
