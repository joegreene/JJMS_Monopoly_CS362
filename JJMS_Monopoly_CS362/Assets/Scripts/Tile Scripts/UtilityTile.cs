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
		base.PlayerLanded (p);
		if (owner == null)                   
		{
			GUIManager.instance.displayPurchasePanel = true;
			GUIManager.instance.updatePurchasePanel(this);
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
			GUIManager.instance.displayRentPanel = true;
			GUIManager.instance.updateRentPanel(this, this.owner, p);
			int costToPlayer = CalculateRent();
			p.DecreaseCashAmount(costToPlayer);
			owner.IncreaseCashAmount(costToPlayer);
		}
	}
	
	//@TODO (check list of rent tables)
	public override int CalculateRent()
	{
		//At start, player owns at least one of the associated properties (itself)
		int rent_due = 0;

		int randomRoll = Random.Range (2, 13);
		if(associatedProperties[0].owner != null && associatedProperties[1].owner != null)
		{
			rent_due = randomRoll * 10;
		}
		else
		{
			rent_due = randomRoll * 4;
		}
		
		//do other rent calc here

		return rent_due;
	}
}
