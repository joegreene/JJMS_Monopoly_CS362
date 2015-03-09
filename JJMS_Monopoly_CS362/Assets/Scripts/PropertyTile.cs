using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyTile : GameTile {

	//Player-oriented attrib
	public Player owner;
	public List <PropertyTile> associatedProperties;

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

	void PlayerLanded(Player p)
	{
		if (isOwned)
		{

		}
	}

	private void CalculateRent(Player p)
	{
		//At start, player owns at least one of the associated properties (itself)
		int num_owned = 1;

		foreach (PropertyTile property in associatedProperties)
		{
			if(p.OwnsProperty(property))
			{
				num_owned+=1;
			}
		}

		//do other rent calc here
	}

}
