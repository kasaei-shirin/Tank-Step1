using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Objectives: to move the object in 2D motion by draging
public class DragObject : MonoBehaviour
{

    private Vector3 mOffset;

    private float mZCoord;

    // when the mouse is clicked, the offset between game object and mouse position
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; // store the z cordination of the game object 
        mOffset = gameObject.transform.position - GetMouseWorldPos(); // get the distance between game object position and mouse position 
    }

    //to get the position of the mouse
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition; // store the position of the mouse in the screen (it's X and Y axis)

        mousePoint.z = mZCoord; // store the z cordination of the game object to mouse position variable (it's z axis)

        return Camera.main.ScreenToWorldPoint(mousePoint); // return the position of the mouse (having X,Y and Z axis)
    }

    // when the mouse is dragged, this code is executed
    void OnMouseDrag()
    {
       
        transform.position = GetMouseWorldPos() + mOffset; // add mouse position with the distance between game object position and mouse position 
        Vector3 position = new Vector3(transform.position.x, 0.5f, transform.position.z); // set a fixed value for y axis. therefore, the drag will work only on x and Z axis and Y axis is always the same
        transform.position = position;
        
    }
}
