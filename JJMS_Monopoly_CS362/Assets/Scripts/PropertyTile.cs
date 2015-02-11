using UnityEngine;
using System.Collections;

public class PropertyTile : GameTile {

	public int propertyCost;
	public int numHouses;
	public bool hasHotel;
	public int rentAmount;
	public Player owner;

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
