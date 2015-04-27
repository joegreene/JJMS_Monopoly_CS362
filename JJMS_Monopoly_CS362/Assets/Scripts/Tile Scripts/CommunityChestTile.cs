using UnityEngine;
using System.Collections;

public class CommunityChestTile : GameTile {

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
		string temp = GameManager.instance.eventCards.CommunityChestCards(p);
		GUIManager.instance.updateChancePanel (temp,false);
			

	}
}
