using UnityEngine;
using System.Collections;


public class TestButtonClick : MonoBehaviour {

	public string numberString;
	public bool isClicked = false;
	public int number;
	public string stringToEdit;
	public string player1Bank;
	public double player1;
	public string player2Bank;
	public double player2;
	public double startingBank = 200.00;
	public string bankString;

	// Use this for initialization
	public void ClickTest() 
	{
		isClicked = true;
	}
	
	public void ClickTest2(string text) 
	{
		isClicked = true;
		isClicked = false;
	}
	void Start()
	{
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
			number = getRandomNumber();
			numberString = number.ToString ();
			isClicked = false;
		}
	}
	void OnGUI () 
	{
		player1 += startingBank;
		player2 += startingBank;
		player1Bank = player1.ToString();
		player2Bank = player2.ToString();
		stringToEdit = UnityEngine.GUI.TextField (new Rect (300, 182, 20, 20), numberString, 4);
		player1Bank = UnityEngine.GUI.TextField (new Rect (65, 8, 60, 20), player1Bank, 30);
	}

}
