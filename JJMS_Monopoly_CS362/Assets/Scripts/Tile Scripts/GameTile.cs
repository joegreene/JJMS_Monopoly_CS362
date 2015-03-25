using UnityEngine;
using System.Collections;

using MonopolyProject;

public abstract class GameTile : MonoBehaviour 
{
    //only thing that is in all game tiles
	public string tileName;

	// Use this for initialization (nothing so far)
	void Start () 
	{
		
	}

	abstract void PlayerLanded(ref Player p);

}
