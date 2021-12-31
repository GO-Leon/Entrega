using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] protected EnemyData eData;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private Animator animEnemyShooter;
    [SerializeField] private int lifeShooter = 1;
    [SerializeField] float collisionEnemy = 1f;
    private float collisionEnemyTime = 5f;
    //[SerializeField] private float distanceRay = 20f;
    //[SerializeField] private int coolDown = 4;
    //[SerializeField] private float timeShoot = 4;
    //private bool canshoot = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    
    {
        if(lifeShooter>0){
                    if (eData.canshoot)  {
        RaycastShoot();
    }
    else
    {
            eData.timeShoot += Time.deltaTime;
    }
    if(eData.timeShoot > eData.coolDown)
    {
            eData.canshoot = true;
    }
        }

        
        collisionEnemyTime += Time.deltaTime;
        if (collisionEnemy < collisionEnemyTime && collisionEnemyTime < 3f)
        {
            
            animEnemyShooter.SetTrigger("isDead");
            lifeShooter--;
            //breakParticle.Play();


        }
        
    }

    private void RaycastShoot()
    {
        RaycastHit hit;
       if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward), out hit, eData.distanceRay))
       {
           Debug.Log("Player detectado");
            eData.canshoot = false;
            eData.timeShoot = 0;
           GameObject b = Instantiate(enemyBulletPrefab, shootPoint.transform.position, enemyBulletPrefab.transform.rotation);
           b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.TransformDirection(Vector3.forward) * 30f, ForceMode.Impulse);
            //animEnemyShooter.SetBool("isThere", true);
            animEnemyShooter.SetTrigger("isTiro");
        }
       else
        {
            animEnemyShooter.SetBool("isThere", false);
            eData.canshoot = true;
        }
    }
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.green;
        Gizmos.DrawRay(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward) * eData.distanceRay);
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            collisionEnemyTime = 0.0f;
            Debug.Log("Atacaste al enemigo");
            //breakParticle.Stop();
        }
    }
}
