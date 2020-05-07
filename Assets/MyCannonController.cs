using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCannonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Debug.Log("In Start");
		if (!Input.gyro.enabled)
		{
			Debug.Log("Gyro Enabled");
			Input.gyro.enabled = true;
		}

	}

	// Update is called once per frame
	void Update () {
		//transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
		transform.Rotate(0f, 0f, Input.gyro.rotationRateUnbiased.z);

	}
}
