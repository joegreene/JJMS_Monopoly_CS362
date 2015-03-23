using UnityEngine;
using System.Collections;


public class TestButtonClick : MonoBehaviour {
	public GUIText buttonText;
	public string numberString;
	public bool isClicked = false;
	public int number;
	public string stringToEdit;
	// Use this for initialization
	public void ClickTest() {
		//Debug.Log ("clicked");
		isClicked = true;
		//buttonText.text = getRandomNumber().ToString();


	}
	
	public void ClickTest2(string text) {

		Debug.Log (text);
		isClicked = true;
		buttonText.text = getRandomNumber().ToString();
		isClicked = false;

	}
	void Start()
	{
		//number = Random.Range(2, 13);
	}

	public int getRandomNumber()
	{
		number = Random.Range(2, 13);
		numberString = number.ToString ();
		return number;
	}
	void Update()
	{
		if (isClicked == true) 
		{
	
			buttonText.text = getRandomNumber().ToString();
			isClicked = false;
		}
	}
	void OnGUI () {
				stringToEdit = UnityEngine.GUI.TextField (new Rect (300, 182, 20, 20), numberString, 4);
		}

}
