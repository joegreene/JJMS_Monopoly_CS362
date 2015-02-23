using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (GameManager.instance.freeRoamMode)
		{
			if (Input.GetKey (KeyCode.W))
			{
				transform.Translate(0, 0, 5*Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.S))
			{
				transform.Translate(0, 0, -5*Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.A))
			{
				transform.Translate(-5*Time.deltaTime, 0, 0);
			}
			if (Input.GetKey (KeyCode.D))
			{
				transform.Translate(5*Time.deltaTime, 0, 0);
			}
		}
	}
}