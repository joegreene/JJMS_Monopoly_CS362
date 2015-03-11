using UnityEngine;
using System.Collections;

using MonopolyProject;

public class RailroadTile : PropertyTile {

	//NOTE: Start and Update made in PropertyTile already (no need to implement here I believe)

	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}

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
		
		//do other rent calc here
	}

}
