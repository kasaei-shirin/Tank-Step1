using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    float x;
    float z;
    Vector3 pos;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                  
            StartCoroutine(ExecuteAfterTime()); // it execute the delay function
           
        }
    }

    // the delay function

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(2);

        // Code to execute after the delay

        x = Random.Range(-24, 23);

        z = Random.Range(0, 22);
        pos = new Vector3(x, transform.position.y, z);
        transform.position = pos;
    }
}
