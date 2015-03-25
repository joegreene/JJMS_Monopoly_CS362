using UnityEngine;
using System.Collections;

using MonopolyProject;

public class UtilityTile : PropertyTile {

	//NOTE: Start and Update made in PropertyTile already (no need to implement here I believe)
	
	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}
	
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
  
	//@TODO (check list of rent tables)
	private int CalculateRent(ref Player p, ref Player owner)
	{
		//At start, player owns at least one of the associated properties (itself)
		int rent_due = 0;
	  //NOTE: need to implement below method
	  if(owner.OwnsProperty(property))
	  {
	  	rent_due+=(property.baseRentAmount);
		}
		
		//do other rent calc here
	}
}
