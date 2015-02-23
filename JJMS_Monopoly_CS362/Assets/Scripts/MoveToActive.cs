using UnityEngine;
using System.Collections;

public class MoveToActive : MonoBehaviour {
	public GameObject activeUnit;
	// Use this for initialization
	void Start () {
		transform.position = activeUnit.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = activeUnit.transform.position;
	}
}
