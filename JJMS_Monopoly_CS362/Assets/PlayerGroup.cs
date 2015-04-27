using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGroup : MonoBehaviour {

	public Text playerName;
	public Text playerScore;
	public Text playerNumber;
	public Image backGround;
	public Player myPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		backGround.color = Color.white;
		if(myPlayer == GameManager.instance.getCurrentPlayer())
		{
			backGround.color = Color.green;
		}
		playerScore.text = myPlayer.cashAmount.ToString();
	}

	public void init(Player player)
	{
		myPlayer = player;
		playerName.text = player.name;
		playerScore.text = player.cashAmount.ToString();
		playerNumber.text = GameManager.instance.players.FindIndex ((Player obj) => obj == player).ToString();

	}
}
