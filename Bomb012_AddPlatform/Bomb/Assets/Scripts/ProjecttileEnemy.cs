using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ProjecttileEnemy : MonoBehaviour
{
   
    public Rigidbody bulletPrefabs;
    public GameObject player;
  //  GameObject test;
    public LayerMask layer;
    private Camera cam;
    public Transform shootPoint;
    Rigidbody obj;
    // varaibles to fire each second
    float fireRate, nextFire;
    //List of enemy
   public TriggerPlayer[] allPlayers;
    void Start()
    {
        cam = Camera.main;
        // variables for each second fire 
        fireRate = 1f;
        nextFire = Time.time;
    }

   
    void Update()
    {
        if (Share.attackButton)
        {
            LanuchProjecttile();
        }
    }

    void LanuchProjecttile()
    {
        allPlayers = GameObject.FindObjectsOfType<TriggerPlayer>();
     
        {
            foreach (TriggerPlayer currentEnemy in allPlayers)

            {
                
               if (allPlayers[0].transform.position == currentEnemy.transform.position) 
             
                {
                   // Debug.Log(currentEnemy.transform.position);
                    // get teh position of lastenemy from score scripts 
                  Score test1 = player.GetComponent<Score>();
                    GameObject myp = test1.lastPlayer;
                    // create two positopn near the player object Random give a little bet far from the player object position
                    Vector3 position = new Vector3(currentEnemy.transform.position.x /*+ *//*Random.Range(-2, 2)*/, currentEnemy.transform.position.y /*+ 1*/, currentEnemy.transform.position.z /*+*//* Random.Range(-5, 5)*/);
                    // Vector3 position = new Vector3(myp.transform.position.x + Random.Range(-2, 2), myp.transform.position.y + 1, myp.transform.position.z +Random.Range(-5, 5));
                    // give the exact position of player then the boomber look at that position exactly 
                    Vector3 position1 = new Vector3(allPlayers[0].transform.position.x, allPlayers[0].transform.position.y, allPlayers[0].transform.position.z);
                    //calculate the speed of bullet with tht method
                    Vector3 Vo = CalculateVelocity(position1, shootPoint.position, 1f);
                   // Vector3 Vo = CalculateVelocity(position, shootPoint.position, 1f);
                    //canon look at the place you click
                transform.rotation = Quaternion.LookRotation(Vo);
                    // if the button click then bullet create
                    if (Time.time > nextFire)
                    {

                        obj = Instantiate(bulletPrefabs, shootPoint.position, transform.rotation);
                        // it change the velocity of each bullet to the new velocity from CalculateVelocity methood
                        obj.velocity = Vo;
                        nextFire = Time.time + fireRate;
                    }
                    
                    //  if(currentEnemy.health<0)  { continue; }

                }
            }
            if (allPlayers.Length == 0) { Share.ListPlayerDestroy = true; }
        }
        
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {

        // define distance x and y
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;
        //Creat a float the represent our distance
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        // Vx and Vy comes from furmola which calculate velocity based on x and y axes
        float Vx = Sxz / time;
        //Physics.gravity.y  is negative we use Mathf.Abs() to change it positive
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
        Vector3 result = distanceXZ.normalized;
        result *= Vx;
        result.y = Vy;
        return result;
    }
   
}
