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
		GUIManager.instance.displayChancePanel = true;
		GUIManager.instance.updateChancePanel("Go to jail!\n Do NOT pass go, do NOT collect $200. You lose your next turn!", 4);
		GameManager.instance.chanceAction = true;
		p.destinationTile = GameManager.instance.gameBoard [10];
		p.currentTileIndex = 10;
		p.inJail = true;
		p.isMoving = true;
		
		//Move player to jail tile (index)
		//GameManager.instance.MovePlayerTo(p.GetIndex(), 10);
	}
}
