using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public float speedEnemy = 4.0f;
    public float liveEnemy = 7.0f;
    private GameObject player;
    [SerializeField] private Vector3 enemyDistance = new Vector3(2, 0, 0);
    enum EnemyAction {Chase , Look};
    [SerializeField] private EnemyAction action;
    [SerializeField] private float speedLookEnemy = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        switch (action)
        {
            case EnemyAction.Chase:
            Debug.Log("Perseguir player");
            speedLookEnemy = 0.0f;
            break;
            case EnemyAction.Look:
            Debug.Log("Observar player");
            speedEnemy = 0.0f;
            break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        LookAtPlayer();

   
    }

    private void ChasePlayer()
    {
        Vector3 direction = player.transform.position - transform.position - enemyDistance;
        transform.position += speedEnemy * direction * Time.deltaTime;
    }
        private void LookAtPlayer() {
        Quaternion newRotation = Quaternion.LookRotation((player.transform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedLookEnemy * Time.deltaTime);
    }
}
