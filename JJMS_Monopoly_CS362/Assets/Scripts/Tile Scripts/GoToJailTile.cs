using UnityEngine;
using System.Collections;

public class GoToJailTile : GameTile {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void PlayerLanded(Player p)
	{
		base.PlayerLanded (p);
		p.destinationTile = GameManager.instance.gameBoard [10];
		p.isMoving = true;
		GameManager.instance.nextTurn ();
		//Move player to jail tile (index)
		//GameManager.instance.MovePlayerTo(p.GetIndex(), 10);
	}
}
