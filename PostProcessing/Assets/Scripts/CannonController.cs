using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{   [SerializeField] private float distanceRay = 19f;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private int coolDown = 2;
    [SerializeField] private float timeShoot = 2;
    private bool canshoot = true;
    [SerializeField] private GameObject cannonBulletPrefab;
    [SerializeField] private ParticleSystem shootParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (canshoot) {
        RaycastShoot();
    }
    else
    {
        timeShoot += Time.deltaTime;
    }
    if(timeShoot > coolDown)
    {
        canshoot = true;
    }
        
    }

    private void RaycastShoot()
    {
        RaycastHit hit;
       if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward), out hit, distanceRay))
       {
           Debug.Log("Player detectado");
           canshoot = false;
           timeShoot = 0;
           GameObject b = Instantiate(cannonBulletPrefab, shootPoint.transform.position, cannonBulletPrefab.transform.rotation);
           b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.TransformDirection(Vector3.forward) * 40f, ForceMode.Impulse);
            shootParticle.Play();
        }
       else
        {
            shootParticle.Stop();
        }
    }
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward) * distanceRay);
    }
}
