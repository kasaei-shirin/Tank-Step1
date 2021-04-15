using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotationSpeed = 250.0f;
	
	
	void Update () {
		
		transform.Rotate(new Vector3(   0 , 0 ,  rotationSpeed * Time.deltaTime));
	}

}
