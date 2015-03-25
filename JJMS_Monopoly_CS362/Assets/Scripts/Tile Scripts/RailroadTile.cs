using UnityEngine;
using System.Collections;

using MonopolyProject;

public class RailroadTile : PropertyTile {


	// Use this for initialization
	void Start () {
		//No need for this variable
		numHouses = -1;
	}
	
	void PlayerLanded(ref Player p)
	{
		//Get owner to determine event below
		Player owner = GameManager.instance.GetPropertyOwner(this);
		
		if (owner.GetPlayerName() == null)                   
		{
			//Option to purchase property
		
			//whatever output to GUI goes here for asking user (leave as option on side or in a menu)
			
			//if player chooses to purchase, decrease cost from player, add property to player, 
			//and set owner variable in this object to player name
				//p.DecreaseCashAmount(propertyCost);
				//p.AddPropertyTile(this);
				//this.owner = p.GetPlayerName();
		}
		else if (owner.GetPlayerName() == p.GetPlayerName()) 
		{
			//do nothing
		}
		else
		{
			//Player must pay rent to owner
			
			int costToPlayer = CalculateRent(owner);
			p.DecreaseCashAmount(costToPlayer);
			owner.IncreaseCashAmount(costToPlayer);
		}
	}

	/*
	 * Function to calculate rent (not sure if need reference or pass by-value is fine)
	 * http://en.wikibooks.org/wiki/Monopoly/Official_Rules#Properties.2C_Rents.2C_and_Construction
	 */
	private int CalculateRent(Player owner)
	{
		//At start, player owns at least one of the associated properties (itself)
		int rrOwned = 1;
		
		//Check if owner has each rail road tile to calculate rent
		foreach (PropertyTile property in associatedProperties)
		{
			if(owner.OwnsProperty(property))
			{
				count++;
			}
		}
		//Returned rent is 25 * 2^(num_railroads_owned - 1)
		return 25 * pow(2.0, count-1);
	}
}