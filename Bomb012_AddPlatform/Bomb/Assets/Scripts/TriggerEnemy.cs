using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;


public class TriggerEnemy : MonoBehaviour
{
   // all detail are the same with Trigger player 
   
    int health = 100;
    // int CountBullt,Count2,Count3 = 0;
    // int countDestroy = 0;
    // public Text scorePlayer;

    
    
    void Update()
    {
        if (health <= 0)
        {
            Share.destroy_enemy = true;
            Destroy(gameObject);

          //  countDestroy += 1;
           // scorePlayer.text ="Player Score: " + countDestroy.ToString();
        }
    }
    // detec the collison of original bomb and objects
    void OnCollisionEnter(Collision collisionInfo)
    {
        
     
        if (collisionInfo.collider.tag == "Bullet" && Share.check_01 && Share.destroy_flag1)
        {

            health -= 30;
            Share.check_01 = false;
            Share.destroy_flag1 = false;
            //CountBullt++;
            //Debug.Log(health);
            //Debug.Log("CountBullt  :"+CountBullt);

        }
    }
    // detect teh two domain of bomb with an object
    private void OnTriggerEnter(Collider other)
    {
      
       

        if (other.tag == "Sphere2" && Share.check_Sphere2 && Share.destroy_flag2)
        {
            health -= 15;
            Share.check_Sphere2 = false;
            Share.destroy_flag2 = false;
            // Count2++;
            // Debug.Log(health);
            //Debug.Log("Count2 :" + Count2);

        }

        if (other.tag == "Sphere3" && Share.check_Sphere3 && Share.destroy_flag3)
        {
            health -= 35;
            Share.check_Sphere3 = false;
            Share.destroy_flag3 = false;
            //Count3++;
            // Debug.Log(health);
            //Debug.Log("Count3  :" + Count3);

        }

    
    }

}
