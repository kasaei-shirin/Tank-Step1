using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody bulletPrefabs;
    public GameObject cursor;
    public LayerMask layer;
    private Camera cam;
    public Transform shootPoint;
    Rigidbody obj;
    void Start()
    {
        cam = Camera.main;  
    }

    // Update is called once per frame
    void Update()
    {
        LanuchProjecttile();
       
    }

    void LanuchProjecttile() {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;
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

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time) {

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
