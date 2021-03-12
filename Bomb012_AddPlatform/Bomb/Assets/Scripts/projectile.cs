using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class projectile : MonoBehaviour
{
    // refrence to teh bullet that we want to produce
    public Rigidbody bulletPrefabs;
    // 
    public GameObject cursor;
    // let us to know which object shoot out
    public LayerMask layer;
    // 
    private Camera cam;

    //To have access to pasueMenu
    public GameObject pauseMenu;

    public Transform shootPoint;
    Rigidbody obj;
    void Start()
    {
        
        cam = Camera.main;  
    }

   
    void Update()
    {
        // Pause game an open pause menu stop the game
        if (Input.GetKeyDown(KeyCode.P)) {
            Share.attackButton = false;
            pauseMenu.SetActive(true);

        }

        if (Share.attackButton)
        {
            LanuchProjecttile();
        }
       
       
    }
    // throwing method
    void LanuchProjecttile() {
        // we shoot from this ray to teh world it bring back the ray from camer to the screen points
        //It calculate teh position of mouse on the world
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        //hit infor
        RaycastHit hit;
        // if ray cast hit some thing then we put information to the hit variable the ditance is 100 f
        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {// if we hit some thing cursor os active the set teh cursor position with the hit point
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;
           //******************** here you give the time 1f with thei we can have slowe or faster time
            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f);
            //canon look at the place you click
            transform.rotation = Quaternion.LookRotation(Vo);
            if (Input.GetMouseButtonDown(0))
            {

               obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                // it change the velocity of each bullet to the new velocity from CalculateVelocity methood
                obj.velocity = Vo;
                
            }

        }
        else {
            cursor.SetActive(false);
        }
    }
    // Calculate the velocity of bullet ,it has start point end point and time
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time) {

        // define distance x and y
        Vector3 distance = target - origin;
        //for X and Z it has the same distance with th target or end point but for Y it has another distance("chon Y yani cheghadr bere bala")
        Vector3 distanceXZ = distance;
        // It just keep the distance of z and x
        distanceXZ.y = 0f;
        //Creat a float the represent our distance
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        // Vx and Vy comes from furmola which calculate velocity based on x and y axes
        float Vxz = Sxz / time;
        //Physics.gravity.y  is negative we use Mathf.Abs() to change it positive
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
        // we apply the two velocities that  we calulate to the new position (result)
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;
    }

}
