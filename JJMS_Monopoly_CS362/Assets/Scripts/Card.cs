using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	int numChanceCards = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
	int numCcCards = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

	public string chancecard1 = "Advance to go - collect $200";
	public string chancecard2 = "Advance to Illinois Ave";
	public string chancecard3 = "Advance token to nearest Utility - if unowned, you may buy it from the bank, if owned, throw dice and pay owner a total ten times the amount thrown.";
	public string chancecard4 = "Advance token to nearest Railroad and pay owner twice the rental, if unowned you may buy it from the bank.";
	public string chancecard5 = "Advance token to nearest Railroad and pay owner twice the rental, if unowned you may buy it from the bank";
	public string chancecard6 = "Advance to St. Charles Place - if you pass GO collect $200";
	public string chancecard7 = "Bank pays you dividend of $50";
	public string chancecard8 = "Get out of jail free - kept until needed";
	public string chancecard9 = "Go back 3 places";
	public string chancecard10 = "Go directly to jail - do not pass go, do not collect $200";
	public string chancecard11 = "Make general repairs on all your properties - for each house pay $25, for each hotel pay $100";
	public string chancecard12 = "Pay poor tax of $15";
	public string chancecard13 = "ake a trip to Reading Railroad - if you pass GO collect $200";
	public string chancecard14 = "Take a walk on Boardwalk - Advance token to boardwalk";
	public string chancecard15 = "You have been elected chairman of the board - Pay each player $50";
	public string chancecard16 = "Your building and loan matures - Collect $150";


	public string cccard1 = "Advance to GO - Collect $200";
	public string cccard2 = "Bank Error in your favor - Collect $200";
	public string cccard3 = "Doctor's Fee - Pay $50";
	public string cccard4 = "Sale of Stock - Collect $50";
	public string cccard5 = "Get out of jail free - Keep until needed";
	public string cccard6 = "Go to jail - Do not pass GO, Do not collect $200";
	public string cccard7 = "Grand Opera Night - Collect $50 from every player";
	public string cccard8 = "Holiday Fund Matures - Collect $100";
	public string cccard9 = "Income Tax Refund - Collect $20";
	public string cccard10 = "Receive Consultancy Fee - Collect $25";
	public string cccard11 = "Life Insurance Matures - Collect $100";
	public string cccard12 = "Pay Hospital Fees - Pay $100";
	public string cccard13 = "Pay School Fees - Pay $150";
	public string cccard14 = "Assessed for street repairs - Pay $40 per house and $115 per hotel";
	public string cccard15 = "2nd Prize in Beauty Contest - Collect $10";
	public string cccard16 = "Inherit $100 - Collect $100";


	public int randomChance;
	public int randomCC;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*There will be two functions need for the card class
	 * move the player
	 * and increase or decrease the players money in bank.
	 * To move the player you call a function in the player class.
	 * To increase or decrease the players money in bank you will 
	 * call another function to do it for you. */

	public int getRandomChance()
	{
		randomChance = Random.Range (1, 17);
		return randomChance;
	}

	public int getRandomCC()
	{
		randomCC = Random.Range (1, 17);
		return randomCC;
	}

	public void ChanceCards()
	{
		randomChance = getRandomChance ();

		if (randomChance == 1) 
		{
			print (chancecard1);
			//move player
		}
		if (randomChance == 2) 
		{
			print (chancecard2);
			//move player
		}
		if (randomChance == 3) 
		{
			print (chancecard3);
			//move player
		}
		if (randomChance == 4) 
		{
			print (chancecard4);
			//move player
		}
		if (randomChance == 5) 
		{
			print (chancecard5);
			//move player
		}
		if (randomChance == 6) 
		{
			print (chancecard6);
			//move player
		}
		if (randomChance == 7) 
		{
			print (chancecard7);
			//money
		}
		if (randomChance == 8) 
		{
			print (chancecard8);
			//??
		}
		if (randomChance == 9) 
		{
			print (chancecard9);
			//move player
		}
		if (randomChance == 10) 
		{
			print (chancecard10);
			//move player
		}
		if (randomChance == 11) 
		{
			print (chancecard11);
			//money
		}
		if (randomChance == 12) 
		{
			print (chancecard12);
			//money
		}
		if (randomChance == 13) 
		{
			print (chancecard13);
			//move player
		}
		if (randomChance == 14) 
		{
			print (chancecard14);
			//move player
		}
		if (randomChance == 15) 
		{
			print (chancecard15);
			//money
		}
		if (randomChance == 16) 
		{
			print (chancecard16);
			//money
		}

	}
	public void CommunityChestCards()
	{
		randomCC = getRandomCC ();

		if (randomCC == 1) 
		{
			print (cccard1);
			//move player
		}
		if (randomCC == 2) 
		{
			print (cccard2);
			//money
		}
		if (randomCC == 3) 
		{
			print (cccard3);
			//money
		}
		if (randomCC == 4) 
		{
			print (cccard4);
			//money
		}
		if (randomCC == 5) 
		{
			print (cccard5);
			//??
		}
		if (randomCC == 6) 
		{
			print (cccard6);
			//move player
		}
		if (randomCC == 7) 
		{
			print (cccard7);
			//money
		}
		if (randomCC == 8) 
		{
			print (cccard8);
			//money
		}
		if (randomCC == 9) 
		{
			print (cccard9);
			//money
		}
		if (randomCC == 10) 
		{
			print (cccard10);
			//money
		}
		if (randomCC == 11) 
		{
			print (cccard11);
			//money
		}
		if (randomCC == 12) 
		{
			print (cccard12);
			//money
		}
		if (randomCC == 13) 
		{
			print (cccard13);
			//money
		}
		if (randomCC == 14) 
		{
			print (cccard14);
			//money
		}
		if (randomCC == 15) 
		{
			print (cccard15);
			//money
		}
		if (randomCC == 16) 
		{
			print (cccard16);
			//money
		}
		
	}
	

}
