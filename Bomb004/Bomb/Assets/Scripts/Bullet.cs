using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 3f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 0f;
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {


        //countdown -= Time.deltaTime;
        //if (countdown <= 0f && !hasExploded) {
        //    Expolde();
        //    hasExploded = true;
        //}
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Enemy" && !hasExploded) {
           
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
                rb.AddExplosionForce(force, transform.position, radius);
            }

          
            //Damage
        }

        // Damage
        // Remove grenade
        Destroy(gameObject);
    }
}
