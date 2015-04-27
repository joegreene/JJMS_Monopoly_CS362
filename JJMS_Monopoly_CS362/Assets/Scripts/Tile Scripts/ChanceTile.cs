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
		string temp = GameManager.instance.eventCards.ChanceCards(p);
		GUIManager.instance.updateChancePanel (temp,true);
	
	}
}
