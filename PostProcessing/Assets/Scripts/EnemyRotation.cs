using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float speedLookEnemy = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }
    private void LookAtPlayer() {
        Quaternion newRotation = Quaternion.LookRotation((player.transform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedLookEnemy * Time.deltaTime);
    }
}
