using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Bullet : MonoBehaviour
{


    // 1 for the grenade to blow up after 3 seconds
    // public float delay = 3f;
    // float countdown;
    // 1*
    // let to explid one time
    bool hasExploded = false;
    // Animation effect object to intilated later
    public GameObject explosionEffect;
    //domin to exploid and effect objects
    public float radius = 5f;
    //force for let objects jump as the bullet  exploid
    public float force = 0f;
    void Start()
    {//1
       // countdown = delay;
       //1*
    }

   
    void Update()
    {

        //1
        //countdown -= Time.deltaTime;
        //if (countdown <= 0f && !hasExploded) {
        //    Expolde();
        //    hasExploded = true;
        //}
        //*1
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Enemy" && !hasExploded) {

            // use the flags to do not let each collider of bullets counts more than one time to decrese the health
            Share.check_01 = true;
            Share.check_Sphere2 = true;
            Share.check_Sphere3 = true;
            Expolde();
           
            hasExploded = true;
           
        }

       
    }

    void Expolde() {
        // show effect
        Instantiate(explosionEffect, transform.position,transform.rotation);

        //Get Nearby Object: introduce a 
        // introduce a sphere with radius of 5 and we read all objects taht have collider in this rigion
        Collider[] colliders= Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            //we copy object to the rb to inser force and then the object jump 
            Rigidbody rb= nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                //Add force
               // rb.AddExplosionForce(force, transform.position, radius);
            }

          
            //Damage
        }

        // Damage
        // Remove grenade
        Destroy(gameObject);
        Share.destroy_flag1 = true;
        Share.destroy_flag2 = true;
        Share.destroy_flag3 = true;
        //  To destroy the object if it fall from the platform.
        if (transform.position.y <= -1)
        {
            Destroy(gameObject);
        }

    }
}
