using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float TimeToLive = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToLive);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
