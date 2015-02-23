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

		Quaternion newRotation = Quaternion.AngleAxis (angle, Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, speed);
		if(Mathf.Abs(transform.rotation.eulerAngles.x - newRotation.eulerAngles.x) <= 2.5f && Mathf.Abs(transform.rotation.eulerAngles.y - newRotation.eulerAngles.y) <= 5 && Mathf.Abs(transform.rotation.eulerAngles.z - newRotation.eulerAngles.z) <= 5)
		{
			GameManager.instance.cameraRotating = false;
		}
		else
		{
			GameManager.instance.cameraRotating = true;
		}

	}
}