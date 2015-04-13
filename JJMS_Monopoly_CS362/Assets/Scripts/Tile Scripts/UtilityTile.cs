using UnityEngine;
using System.Collections;

public class UtilityTile : PropertyTile {
	
	//NOTE: Start and Update made in PropertyTile already (no need to implement here I believe)
	
	// Use this for initialization
	void Start () {
		associatedProperties.Add(GameManager.instance.gameBoard[12] as PropertyTile);  //electric company
		associatedProperties.Add(GameManager.instance.gameBoard[28] as PropertyTile);  //waterworks

		owner = null;                                    //
		numHouses = -1;                                                //no houses
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void PlayerLanded(Player p)
	{	
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
			
			int costToPlayer = CalculateRent();
			p.DecreaseCashAmount(costToPlayer);
			owner.IncreaseCashAmount(costToPlayer);
		}
	}
	
	//@TODO (check list of rent tables)
	private int CalculateRent()
	{
		//At start, player owns at least one of the associated properties (itself)
		int rent_due = 0;

		foreach (PropertyTile property in associatedProperties)
		{
			
			//NOTE: For now, rent is base amount added all together
			if(owner.OwnsProperty(property))
			{
				rent_due+=(property.baseRentAmount);
			}
		}
		
		//do other rent calc here

		return rent_due;
	}
}
