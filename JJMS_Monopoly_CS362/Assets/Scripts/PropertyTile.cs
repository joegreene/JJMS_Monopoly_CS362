using UnityEngine;
using System.Collections;

public class PropertyTile : GameTile {

	//Player-oriented attrib
	public Player owner;
	
	//Property attrib
	public int numHouses;
	public bool isOwned;
	public bool hasHotel;
	public int propertyCost;
	public int rentAmount;


	// Use this for initialization
	void Start () 
	{
		owner = null;
		propertyCost = 0;
		numHouses = 0;
		hasHotel = false; 
		rentAmount = 0; 
	}



}
