using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ButtonBehaviour : MonoBehaviour
{
    int n,z;
    public void OnMovementPress(){

        Share.moveButton = true;
        Share.attackButton = false;
    }

    public void OnAttackPress()
    {
       
        Share.attackButton = true;
        Share.moveButton = false;
      //  z++;
      //  Debug.Log("Button clicked " + z + " times.");
    }

}
