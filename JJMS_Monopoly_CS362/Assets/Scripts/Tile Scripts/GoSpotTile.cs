using UnityEngine;
using System.Collections;

public class GoSpotTile : GameTile {

	// Use this for initialization
	void Start () {
		//unsure if used
	}
	
	// Update is called once per frame
	void Update () {
		//unsure if used
	}
	
	public override void PlayerLanded(ref Player p)
	{
		//Call this only after players have looped around game board 
		//(i.e. do not call on start of game, only afterwards)
		p.IncreaseCashAmount(200);
	}
}
