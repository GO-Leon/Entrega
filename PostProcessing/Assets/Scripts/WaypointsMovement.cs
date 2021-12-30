using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float wpSpeed;
    [SerializeField] float pursuitSpeed;
    [SerializeField] float minDistance;
    [SerializeField] float rotationSpeed;
    private int currentIndex = 0;
    private bool goBack = false;
    [SerializeField] GameObject character;
    [SerializeField] float enemyView;
    [SerializeField] private Animator animBoss;
    [SerializeField] float enemyDistance;
    // Start is called before the first frame update
    void Start()
    {
        animBoss.SetBool("isCharacter", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, character.transform.position) <= enemyView)
        {
            iSeeCharacter = true;
        }
        else
        {
            iSeeCharacter = false;
        }
        if (iSeeCharacter)
        {
            Pursuit();
            animBoss.SetBool("isCharacter", true);
        }
        else
        {
            WPMovement();
            animBoss.SetBool("isCharacter", false);
        }
        
        if (Vector3.Distance(transform.position, character.transform.position) <= enemyDistance)
        {
            animBoss.SetTrigger("enemyAttack");
        }
    }

    private bool iSeeCharacter = false;
    private void Pursuit()
    {
        Debug.Log("Perseguir al heroe");
        Vector3 direction = (character.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * pursuitSpeed * Time.deltaTime;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyView);
    }
}
