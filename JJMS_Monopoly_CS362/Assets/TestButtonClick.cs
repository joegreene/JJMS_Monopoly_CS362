using UnityEngine;
using System.Collections;


public class TestButtonClick : MonoBehaviour {
	public GameObject referencedButton;
	public GUIText buttonText;
	public string numberString;
	public bool isClicked = false;
	public int number;
	// Use this for initialization
	public void ClickTest() {
		Debug.Log ("clicked");
		isClicked = true;
		//buttonText.text = getRandomNumber().ToString();


	}
	
	public void ClickTest2(string text) {

		Debug.Log (text);
		isClicked = true;

		//buttonText.text = getRandomNumber().ToString();

	}
	void Start()
	{
		//buttonText = "";
	}

	public int getRandomNumber()
	{
		number = Random.Range(2, 13);
		return number;
	}
	void Update()
	{
		if (isClicked == true) 
		{
			numberString = getRandomNumber ().ToString ();
			buttonText.text = getRandomNumber ().ToString ();
			//referencedButton.Get
			isClicked = false;
		}
	}

}
