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
		//deduct from player's cash amount by 10% of total property value
		//p.DecreaseCashAmount(.10*p.GetTotalWorth());
	}
}
