using UnityEngine;
using System.Collections;

public abstract class GameTile : MonoBehaviour 
{
    //only thing that is in all game tiles
	public string tileName;

	// Use this for initialization
	void Start () {
		//unsure if used
	}
	
	// Update is called once per frame
	void Update () {
		//unsure if used
	}

	abstract public void PlayerLanded(Player p);
}
