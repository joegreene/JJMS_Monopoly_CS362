using UnityEngine;
using System.Collections;

using MonopolyProject;

public abstract class GameTile : MonoBehaviour {

	public string tileName;



	// Use this for initialization
	void Start () 
	{
	
	}

	void PlayerLanded(ref Player p);

}
