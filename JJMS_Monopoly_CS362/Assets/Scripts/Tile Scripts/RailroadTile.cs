using UnityEngine;
using System.Collections;
using System;

public class RailroadTile : PropertyTile {
	
	// Use this for initialization
	void Start () {
		associatedProperties.Add(GameManager.instance.gameBoard[5]  as PropertyTile);   //Reading
		associatedProperties.Add(GameManager.instance.gameBoard[15] as PropertyTile);   //Pennsylvania
		associatedProperties.Add(GameManager.instance.gameBoard[25] as PropertyTile);   //B & O
		associatedProperties.Add(GameManager.instance.gameBoard[35] as PropertyTile);   //Short Line
	}

	// Update is called once per frame
	void Update () {
		//unsure if used
	}
	
	public override void PlayerLanded(Player p)
	{	
		if (owner == null)                   
		{
			//Option to purchase property
			
			//whatever output to GUI goes here for asking user (leave as option on side or in a menu)
			
			//if player chooses to purchase, decrease cost from player, add property to player, 
			//and set owner variable in this object to player name
			//p.DecreaseCashAmount(propertyCost);
			//p.AddPropertyTile(this);
			//this.owner = p.GetPlayerName();
		}
		else if (owner == p) 
		{
			//do nothing
		}
		else
		{
			//Player must pay rent to owner
			
			int costToPlayer = CalculateRent();
			p.DecreaseCashAmount(costToPlayer);
			owner.IncreaseCashAmount(costToPlayer);
		}
	}
	
	/*
	 * Function to calculate rent (not sure if need reference or pass by-value is fine)
	 * http://en.wikibooks.org/wiki/Monopoly/Official_Rules#Properties.2C_Rents.2C_and_Construction
	 */
	protected override int CalculateRent()
	{
		//At start, player owns at least one of the associated properties (itself)
		int railroadTilesOwned = 1;
		
		//Check if owner has each rail road tile to calculate rent
		foreach (PropertyTile property in associatedProperties)
		{
			if(owner.OwnsProperty(property))
			{
				railroadTilesOwned++;
			}
		}
		//Returned rent is 25 * 2^(num_railroads_owned - 1)
		return 25 * (int)Math.Pow(2.0, railroadTilesOwned-1);
	}
}