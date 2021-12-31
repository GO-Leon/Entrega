using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platformPoints;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlatformsBehavior());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlatformsBehavior()
    {
        for (int i = 0; i < platformPoints.Length; i++)
        {
            while (transform.position != platformPoints[i].transform.position)
            {
                yield return null;
                transform.position = Vector3.MoveTowards(transform.position, platformPoints[i].transform.position, 4f * Time.deltaTime);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
