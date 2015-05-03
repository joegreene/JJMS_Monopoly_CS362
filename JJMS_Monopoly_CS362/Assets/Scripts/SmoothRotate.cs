using UnityEngine;
using System.Collections;

public class SmoothRotate : MonoBehaviour
{
	public int angle;
	public float speed;
	public int timer;
	public int cooldown;

	void Awake()
	{
		angle = -45;
		speed = 3.0f * Time.fixedDeltaTime; 
		timer = 60;
		cooldown = 60;
	}
	
	void FixedUpdate ()
	{
		Vector3 relativePosition = GameManager.instance.getCurrentPlayer().transform.position - transform.position;
		//Quaternion rotation = Quaternion.LookRotation(relativePosition);
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 3f*Time.deltaTime);
		
//		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.up);
//		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, speed);
		if(Mathf.Abs(transform.rotation.eulerAngles.x - rotation.eulerAngles.x) <= 2.5f && Mathf.Abs(transform.rotation.eulerAngles.y - rotation.eulerAngles.y) <= 5 && Mathf.Abs(transform.rotation.eulerAngles.z - rotation.eulerAngles.z) <= 5)
		{
			GameManager.instance.cameraRotating = false;
		}
		else
		{
			GameManager.instance.cameraRotating = true;
		}

	}
}