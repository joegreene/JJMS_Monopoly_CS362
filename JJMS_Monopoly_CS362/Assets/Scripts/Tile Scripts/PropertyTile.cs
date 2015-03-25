using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MonopolyProject;

public class PropertyTile : GameTile {

	//Player-oriented attrib
	private Player owner;         //ask about where we will keep track of this
								  //maybe "HasProperty" method in Player
	public List <PropertyTile> associatedProperties;
								  //either initialize via unity or init function
								  //by-color attribute

	//Property attrib
	public string propertyName;
	public int numHouses;         //ask about where we will keep track of this
								                //maybe "GetNumHouses" method in Player
	public int propertyCost;
	public int baseRentAmount;
	public Color color;


	// Use this for initialization; other values set up in unity
	void Start () 
	{
		//Look through game board and add same-color 
		foreach(GameTile t in GameManager.instance.gameBoard)
		{
			if(t.getComponent<PropertyTile>() != null)
			{
				if(this.color == t.color)
				{
					associatedProperties.Add(t);
				}
			}
		}
		owner.SetName(null);
		numHouses = 0;
	}
	
	/*
	 * Three event may occur if the player lands on a property:
	 *   - If there is no owner, give the lander an option to purchase the property
	 *   - Else if the player is already the owner, give the option to add a house/convert 
	 *     five houses to a hotel
	 * 	 - Otherwise, property is owned already and player must pay rent
	 */
	void PlayerLanded(ref Player p)
	{
		if (owner.GetPlayerName() == null)                     //Option to purchase property
		{
			
			//whatever output to GUI goes here for asking user (leave as option on side or in a menu)
			
			//if player chooses to purchase, decrease cost from player, add property to player, 
			//and set owner variable in this object to p
				//p.DecreaseCashAmount(propertyCost);
				//p.AddPropertyTile(this);
				//this.owner = p;
		}
		else if (owner.GetPlayerName() == p.GetPlayerName())   //player is owner
		{
			//If number of houses on property is less than 4, 
			if(numHouses < 4)
			{
				//do normal house-purchase prompt
				
				//give option on side 
			}
			else if (numHouses == 4)
			{
				//do prompt for convert-to-hotel
			}
			//no else here
		}
		else                                                   //Player must pay rent to owner
		{
			int costToPlayer = CalculateRent(owner);
			p.DecreaseCashAmount(costToPlayer);
			owner.IncreaseCashAmount(costToPlayer);
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

	/*
	 * Function to calculate rent (not sure if need reference or pass by-value is fine)
	 * http://en.wikibooks.org/wiki/Monopoly/Official_Rules#Properties.2C_Rents.2C_and_Construction
	 */
	private int CalculateRent(ref Player owner)
	{
		//At start, player owns at least one of the associated properties (itself)
		int rent_due = 0;

		//Check each associated property to see how much rent is due
		//At the moment, calculate by adding all rents together.
		foreach (PropertyTile property in associatedProperties)
		{
			
			//NOTE: For now, rent is base amount 
			if(owner.OwnsProperty(property))
			{
				rent_due+=(property.baseRentAmount + (property.numHouses*10));
			}
		}

		//do other rent calc here
	}

}
