using UnityEngine;
using System.Collections;

public class LuxuryTaxTile : GameTile {

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
		int amountDue = p.getAllPropertyValues ();
		GUIManager.instance.displayChancePanel = true;
		GUIManager.instance.updateChancePanel ("Luxury Tax\n You owe " + Mathf.RoundToInt (amountDue * 0.1f) + " in luxury taxes!", 3);
		p.DecreaseCashAmount (Mathf.RoundToInt (amountDue * 0.1f));
		//deduct from player's cash amount by 10% of total property value
		//p.DecreaseCashAmount(.10*p.GetTotalWorth());
		GUIManager.instance.rollDice.interactable = true;
	}
}
