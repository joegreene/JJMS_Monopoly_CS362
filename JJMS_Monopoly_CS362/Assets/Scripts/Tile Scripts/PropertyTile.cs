using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyTile : GameTile {
	
	//Player-oriented attrib
	public Player owner;          //player that owns the property
	public List <PropertyTile> associatedProperties;
								  //either initialize via unity or init function
								  //by-color attribute
	
	//Property attrib
	public int numHouses;         //ask about where we will keep track of this
								  //maybe "GetNumHouses" method in Player
	public int propertyCost;
	public int baseRentAmount;
	public int houseCost;
	public string colorType;      //not an actual color, rather color type
	
	
	// Use this for initialization; other values set up in unity
	void Start () 
	{
		//Look through game board and add same-color 
		foreach(GameTile t in GameManager.instance.gameBoard)
		{
			var p = t as PropertyTile;
			if(p != null)
			{
				if(this.colorType == p.colorType)
				{
					associatedProperties.Add(p);
				}
			}
		}
		owner = null;
		numHouses = 0;
	}

	// Update is called once per frame
	void Update () {
		//unsure if used
	}
	
	/*
	 * Three event may occur if the player lands on a property:
	 *   - If there is no owner, give the lander an option to purchase the property
	 *   - Else if the player is already the owner, give the option to add a house/convert 
	 *     five houses to a hotel
	 * 	 - Otherwise, property is owned already and player must pay rent
	 */
	public override void PlayerLanded(Player p)
	{
		base.PlayerLanded (p);
		if (owner == null)                     //Option to purchase property
		{
			GUIManager.instance.displayPurchasePanel = true;
			GUIManager.instance.updatePurchasePanel(this);
			//whatever output to GUI goes here for asking user (leave as option on side or in a menu)
			
			//if player chooses to purchase, decrease cost from player, add property to player, 
			//and set owner variable in this object to p
			//p.DecreaseCashAmount(propertyCost);
			//p.AddPropertyTile(this);
			//this.owner = p;
		}
		else if (owner == p)   //player is owner
		{
			GUIManager.instance.displayHousePanel = true;
			GUIManager.instance.updateHousePanel(this,GameManager.instance.getCurrentPlayer());
		}
		else                                                   //Player must pay rent to owner
		{
			GUIManager.instance.displayRentPanel = true;
			GUIManager.instance.updateRentPanel(this, this.owner, p);
			int costToPlayer = CalculateRent();
			p.DecreaseCashAmount(costToPlayer);
			owner.IncreaseCashAmount(costToPlayer);
		}
	}
	
	int GetBaseRentAmount()
	{
		return baseRentAmount;
	}
	
	/*
	 * Function to calculate rent (not sure if need reference or pass by-value is fine)
	 * http://en.wikibooks.org/wiki/Monopoly/Official_Rules#Properties.2C_Rents.2C_and_Construction
	 */
	public virtual int CalculateRent()
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

		return rent_due;
	}

	
}
