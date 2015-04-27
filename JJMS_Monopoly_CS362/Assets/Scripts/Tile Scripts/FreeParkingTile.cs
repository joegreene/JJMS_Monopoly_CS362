using UnityEngine;
using System.Collections;

public class FreeParkingTile : GameTile {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void PlayerLanded(Player p)
	{
		base.PlayerLanded (p);
		GameManager.instance.nextTurn ();

	}
}
