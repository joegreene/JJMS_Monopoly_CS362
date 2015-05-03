using UnityEngine;
using System.Collections;

public class IncomeTaxTile : GameTile {

	// Use this for initialization
	void Start () {
		//unsure if used
	}
	
	// Update is called once per frame
	void Update () {
		//unsure if used
	}

	public override void PlayerLanded(Player p)
	{
		base.PlayerLanded (p);
		//deduct from player's cash amount by 200
		GUIManager.instance.displayChancePanel = true;
		GUIManager.instance.updateChancePanel ("Income Taxes\n Pay $200 to the bank!", 2);
		p.DecreaseCashAmount(200);
		GUIManager.instance.rollDice.interactable = true;
	}
}
