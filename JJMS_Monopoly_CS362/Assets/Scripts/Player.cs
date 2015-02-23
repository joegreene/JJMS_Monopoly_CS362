using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public string playerName;
	public int playerIndex;
	public int currentMoney;

	private List<GameTile> tilesOwned;


	// Use this for initialization
	void Start () {
	
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
