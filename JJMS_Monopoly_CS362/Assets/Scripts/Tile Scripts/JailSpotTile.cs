using UnityEngine;
using System.Collections;

public class JailSpotTile : GameTile 
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//make sure dice roll is ONLY checked when player has sat on position for awhile
	public override void PlayerLanded(Player p)
	{
		//if (player.HasCard(get_out_of_jail)
		//ask if player wants to use card to get out (or force them to use it)
		//else if (player's dice roll is doubles)
		//get them out of jail (?)
		//else, ask if player wants to pay themselves out (?)
	}


}
