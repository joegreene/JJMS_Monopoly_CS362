using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PropertyTile : GameTile {

	//Player-oriented attrib
	public Player owner;         //ask about where we will keep track of this
								  //maybe "HasProperty" method in Player
	public List <PropertyTile> associatedProperties;

	//Property attrib
	private string propertyName;
	private int numHouses;        //ask about where we will keep track of this
								  //maybe "GetNumHouses" method in Player
	private int propertyCost;
	public int baseRentAmount;
	private string color;


	// Use this for initialization
	void Start () 
	{
		owner = null;
		color = null;
		propertyCost = 0;
		numHouses = 0;
		baseRentAmount = 0; 
	}

	void PlayerLanded(ref Player p)
	{
		if (owner.GetPlayerName() == null)
		{
			//give option to purchase house
				//whatever output to GUI goes here for asking user
				//if chose to purchase
					//p.DecreaseCashAmount(propertyCost);
					//p.AddPropertyTile(this);
		}
		else
		{
			//must pay rent
			p.DecreaseCashAmount(CalculateRent(ref p, ref owner));

		}
	}

	string GetPropertyName()
	{
		return propertyName;
	}

	int GetBaseRentAmount()
	{
		return baseRentAmount;
	}

	//@TODO (check list of rent tables)
	private int CalculateRent(ref Player p, ref Player owner)
	{
		//At start, player owns at least one of the associated properties (itself)
		int rent_due = 0;

		//Check each associated property to see how much rent is due
		//At the moment, calculate by adding all rents together.
		foreach (PropertyTile property in associatedProperties)
		{
			//NOTE: need to implement below method
			if(owner.OwnsProperty(property))
			{
				rent_due+=(property.baseRentAmount);
			}
		}
		return rent_due;

		//do other rent calc here
	}

}
