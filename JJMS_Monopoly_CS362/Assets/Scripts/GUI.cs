using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {
	public string stringToEdit ;
	public int number;
	//public int number = Random.Range (2,12);
	private void Start()
	{
		number = Random.Range (2, 12);
		stringToEdit = "0";
		}
	private void Update()
	{
		}
		void OnGUI () {
		stringToEdit = UnityEngine.GUI.TextField(new Rect(5, 5, 20, 20), stringToEdit, 5);

		if (UnityEngine.GUI.Button (new Rect (15, 15, 100, 50), "Roll Dice")) 
		{
			stringToEdit = number.ToString ();
		}
		if (UnityEngine.GUI.Button (new Rect (15, 100, 120, 50), "Check Bank")) 
		{
			transform.position += new Vector3(0, -0.1f, 0);
		}
	}
}


