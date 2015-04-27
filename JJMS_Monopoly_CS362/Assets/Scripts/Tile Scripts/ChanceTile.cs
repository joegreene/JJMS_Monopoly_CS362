using UnityEngine;
using System.Collections;

public class ChanceTile : GameTile {

	//Call chance deck to get card

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void PlayerLanded(Player p)
	{
		base.PlayerLanded (p);
		GUIManager.instance.rollDice.interactable = true;
		GUIManager.instance.displayChancePanel = true;
		GameManager.instance.eventCards.getRandomChance ();
	
	}
}
