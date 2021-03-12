using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera PlayerCamera;
    public Camera EnemyCamera;
    public Camera OverHeadCamera;

    public GameObject player;
    public GameObject enemy;


    void Update()
    {

        // the view for movement mode
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowPlayerView();
        }

        // the view for attack mode
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // the camera will look from up
            ShowOverheadView();
            StartCoroutine(ExecuteAfterTime());

            
        }
        if (EnemyCamera && Input.GetMouseButtonDown(0))
        {

            Click0();
        }



        // to change the view of camera
        // if (PlayerCamera.enabled == true)
        // {
        //     ShowEnemyView();
        // }
        // else if (EnemyCamera.enabled == true)
        // {
        //     ShowOverheadView();
        // }
        // else if (OverHeadCamera.enabled == true)
        //  {
        //    ShowPlayerView();
        //  }


    }

    public void ShowPlayerView()
    {
        PlayerCamera.enabled = true;
        EnemyCamera.enabled = false;
        OverHeadCamera.enabled = false;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowEnemyView()
    {
        PlayerCamera.enabled = false;
        EnemyCamera.enabled = true;
        OverHeadCamera.enabled = false;
    }

    public void ShowOverheadView()
    {
        PlayerCamera.enabled = false;
        EnemyCamera.enabled = false;
        OverHeadCamera.enabled = true;
    }

    // show the hidden objects within a redius 
    public void Click0()
    {
        // RaycastHit hit = (RaycastHit)h;
        // GameObject hitGameObject = hit.collider.gameObject;

        // Debug.Log("HIT at '" + hit.point + "' RECEIVED IN '" + gameObject.name + "'");


        //Collider[] nearObjects = Physics.OverlapSphere(hit.point, 4F);
        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
           
           Debug.Log(hit.collider.gameObject.name);
            Collider[] nearObjects = Physics.OverlapSphere(hit.point, 4F);

            foreach (Collider enemyCollider in nearObjects)
            {

                Debug.Log(enemyCollider.gameObject.name);
                enemyCollider.gameObject.layer = 0;


            }
        }


        
    }


    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3);

        //to disable the objects in enemy zone

        ShowEnemyView();

      
        
    }
}
