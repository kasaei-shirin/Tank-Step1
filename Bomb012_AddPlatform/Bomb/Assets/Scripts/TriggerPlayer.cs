using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class TriggerPlayer : MonoBehaviour
{
    
    // health of object
    public int health = 100;

    //1 keep the number of total destroy: I calculate this one later on Score script.

    // int countDestroy = 0;
    //ckeep the text of canvas object for pressent the score 
    // public Text scorePlayer;
    // To check three coliders works only one time for each shot 
    // int CountBullt,Count2,Count3 = 0;

    //*1


    void Update()
    {
        // if health zero destroy this object ,"On" flag to know this object dstroy in Score script
        if (health <= 0)
        {
            Share.destroy_player = true;
            Destroy(gameObject);
            //1
            //  countDestroy += 1;
            //   scorePlayer.text = "Enemy Score: " + countDestroy.ToString();
            //*1

        }
    }
    // Detec the collison of original bomb and objects
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet" && Share.check_01 && Share.destroy_flag1)
        {

            health -= 30;
            // turn off flag and did not let to decrease the health more than one time 
            Share.check_01 = false;
            Share.destroy_flag1 = false;
            //1
            // CountBullt++;
            // Debug.Log(health);
            //  Debug.Log("CountBullt  :"+CountBullt);
            //*1
        }
    }
    // Detect teh two domain of bomb with an object and decrease the health 15 and 35 
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Sphere2" && Share.check_Sphere2 && Share.destroy_flag2)
        {
            health -= 15;
            Share.check_Sphere2 = false;
            Share.destroy_flag2 = false;
            //1
            // Count2++;
            //  Debug.Log(health);
            // Debug.Log("Count2 :" + Count2);
            //*1
        }

        if (other.tag == "Sphere3" && Share.check_Sphere3 && Share.destroy_flag3)
        {
            health -= 35;
          Share.destroy_flag3 = false;
            Share.destroy_flag3 = false;
            //1
            // Count3++;
            // Debug.Log(health);
            // Debug.Log("Count3  :" + Count3);
            //*1
        }


    }
}
