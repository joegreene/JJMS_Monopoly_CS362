using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public int currentMoney;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void payBank()
	{
		//player needs to pay bank a certain amount of money
		//need player whose turn it is, and amount of money
	}

	void receiveFromBank()
	{
		//bank pays player certain amount of money
		//need player whose turn it is, and amount of money
	}

	void payPlayers()
	{
		//player pays all other players certain amount of money
		//need player whose turn it is, how many players, and amount of money
	}

	void receiveFromPlayers()
	{
		//player receives certain amount of money from all other players
		//need player whose turn it is, how many players, and amount of money
	}

	void payOnePlayer()
	{
		//player pays one player a certain amount
		//need player whose turn it is, player they need to pay, and amount of money
	}

	void holdOntoGetOutJailCard()
	{
		//player holds onto get out of jail card
		//player whose turn it is
	}

}


/*
 * using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public string playerName;
	public int playerIndex;
	public int currentMoney;
	public int gameBoardIndex;

	private List<GameTile> tilesOwned;


	// Use this for initialization
	void Awake () 
	{
		tilesOwned = new List<GameTile>();
		currentMoney = 1000;
		playerIndex = GameManager.instance.players.Count - 1;
		gameBoardIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//checks to see if a specific tile is owned by a player,
	public bool playerOwnsProperty(GameTile tileToCheck)
	{
		foreach(GameTile tile in tilesOwned)
		{
			if(tile == tileToCheck)
			{
				return true;
			}
		}
		return false;
	}
}
*/