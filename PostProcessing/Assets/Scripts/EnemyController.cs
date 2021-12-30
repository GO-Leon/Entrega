using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speedEnemy = 4.0f;
    public float liveEnemy = 7.0f;
    private GameObject player;
    [SerializeField] private Vector3 enemyDistance = new Vector3(2, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }
    // Update is called once per frame
    void Update()
    {
        ChasePlayer();

   
    }

    private void ChasePlayer()
    {
        Vector3 direction = player.transform.position - transform.position - enemyDistance;
        transform.position += speedEnemy * direction * Time.deltaTime;
    }
}
