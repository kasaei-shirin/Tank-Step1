using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class Trigger : MonoBehaviour
{
    int health = 100;
    int CountBullt,Count2,Count3 = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
    // detec the collison of original bomb and objects
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet" && Share.check_01)
        {
           
            health -= 30;
            CountBullt++;
          Debug.Log(health);
            Debug.Log("CountBullt  :"+CountBullt);
            Share.check_01 = false;
        }
    }
    // detect teh two domain of bomb with an object
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Sphere2" && Share.check_Sphere2)
        {
            health -= 15;
            Count2++;
            Debug.Log(health);
            Debug.Log("Count2 :" + Count2);
            Share.check_Sphere2 = false;
        }

        if (other.tag == "Sphere3" && Share.check_Sphere3)
        {
            health -= 35;
            Count3++;
            Debug.Log(health);
            Debug.Log("Count3  :" + Count3);
         Share.check_Sphere3 = false;
        }

        //  Debug.Log(other.tag);
    }




}
