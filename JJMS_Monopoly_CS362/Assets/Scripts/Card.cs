using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

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
	public string chancecard13 = "Take a trip to Reading Railroad - if you pass GO collect $200";
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

	public void ChanceCards(Player player)
	{
		randomChance = getRandomChance ();

		if (randomChance == 1) 
		{
			print (chancecard1);
			player.destinationTile = GameManager.instance.gameBoard[0];
			player.isMoving = true;
			player.cashAmount += 200;
			//move player to GO
		}
		else if (randomChance == 2) 
		{
			print (chancecard2);
			player.destinationTile = GameManager.instance.gameBoard[24];
			player.isMoving = true;
			//move player to Illinois Ave
		}
		else if (randomChance == 3) 
		{
			print (chancecard3);
			if(player.currentTileIndex > 28 || player.currentTileIndex < 13)
			{
				player.destinationTile = GameManager.instance.gameBoard[12];
				player.isMoving = true;
			}
			else 
			{
				player.destinationTile = GameManager.instance.gameBoard[28];
				player.isMoving = true;
			}
			//move player to nearest Utility
		}
		else if (randomChance == 4) 
		{
			print (chancecard4);
			if(player.currentTileIndex > 35 || player.currentTileIndex < 6)
			{
				player.destinationTile = GameManager.instance.gameBoard[5];
				player.isMoving = true;
			}
			else if(player.currentTileIndex > 5 && player.currentTileIndex < 16)
			{
				player.destinationTile = GameManager.instance.gameBoard[15];
				player.isMoving = true;
			}
			else if(player.currentTileIndex > 15 && player.currentTileIndex < 26)
			{
				player.destinationTile = GameManager.instance.gameBoard[25];
				player.isMoving = true;
			}
			else
			{
				player.destinationTile = GameManager.instance.gameBoard[35];
				player.isMoving = true;
			}

			//move player to nearest Railroad
		}
		else if (randomChance == 5) 
		{
			print (chancecard5);
			if(player.currentTileIndex > 35 || player.currentTileIndex < 6)
			{
				player.destinationTile = GameManager.instance.gameBoard[5];
				player.isMoving = true;
			}
			else if(player.currentTileIndex > 5 && player.currentTileIndex < 16)
			{
				player.destinationTile = GameManager.instance.gameBoard[15];
				player.isMoving = true;
			}
			else if(player.currentTileIndex > 15 && player.currentTileIndex < 26)
			{
				player.destinationTile = GameManager.instance.gameBoard[25];
				player.isMoving = true;
			}
			else
			{
				player.destinationTile = GameManager.instance.gameBoard[35];
				player.isMoving = true;
			}
			//move player to nearest Railroad
		}
		else if (randomChance == 6) 
		{
			print (chancecard6);
			//move player to St.Charles Place
			player.destinationTile = GameManager.instance.gameBoard[11];
			player.isMoving = true;
		}
		else if (randomChance == 7) 
		{
			print (chancecard7);
			player.cashAmount += 50;
			//money - receive $50
		}
		else if (randomChance == 8) 
		{
			print (chancecard8);
			//?? get out of jail free card
		}
		else if (randomChance == 9) 
		{
			print (chancecard9);
			player.destinationTile = GameManager.instance.gameBoard[player.currentTileIndex - 3];
			player.isMoving = true;
			//move player back 3 places
		}
		else if (randomChance == 10) 
		{
			print (chancecard10);
			player.destinationTile = GameManager.instance.gameBoard[10];
			player.isMoving = true;
			//move player to jail
		}
		else if (randomChance == 11) 
		{
			print (chancecard11);
			//need to go through a for loop to see how many properties each player owns?
			//money - each house pay $25, for each hotel pay $100
		}
		else if (randomChance == 12) 
		{
			print (chancecard12);
			player.cashAmount -= 15;
			//money - pay $15
		}
		else if (randomChance == 13) 
		{
			print (chancecard13);
			player.destinationTile = GameManager.instance.gameBoard[5];
			player.isMoving = true;
			//move player to Reading Railroad
		}
		else if (randomChance == 14) 
		{
			print (chancecard14);
			player.destinationTile = GameManager.instance.gameBoard[39];
			player.isMoving = true;
			//move player to Boardwalk
		}
		else if (randomChance == 15) 
		{
			print (chancecard15);
			//money - pay each player $50
		}
		else if (randomChance == 16) 
		{
			print (chancecard16);
			player.cashAmount += 150;
			//money - collect $150
		}

	}
	public void CommunityChestCards(Player player)
	{
		randomCC = getRandomCC ();

		if (randomCC == 1) 
		{
			print (cccard1);
			player.destinationTile = GameManager.instance.gameBoard[0];
			player.isMoving = true;
			player.cashAmount += 200;
			//move player - to GO
		}
		else if (randomCC == 2) 
		{
			print (cccard2);
			player.cashAmount += 200;
			//money - collect $200
		}
		else if (randomCC == 3) 
		{
			print (cccard3);
			player.cashAmount -= 50;
			//money - Pay $50
		}
		else if (randomCC == 4) 
		{
			print (cccard4);
			player.cashAmount += 50;
			//money - collect $50
		}
		else if (randomCC == 5) 
		{
			print (cccard5);
			//?? get out of jail free card
		}
		else if (randomCC == 6) 
		{
			print (cccard6);
			player.destinationTile = GameManager.instance.gameBoard[10];
			player.isMoving = true;
			//move player - Go to jail
		}
		else if (randomCC == 7) 
		{
			print (cccard7);
			//money - collect $50 from every player
		}
		else if (randomCC == 8) 
		{
			print (cccard8);
			player.cashAmount += 100;
			//money - collect $100
		}
		else if (randomCC == 9) 
		{
			print (cccard9);
			player.cashAmount += 20;
			//money - collect $20
		}
		else if (randomCC == 10) 
		{
			print (cccard10);
			player.cashAmount += 25;
			//money - collect $25
		}
		else if (randomCC == 11) 
		{
			print (cccard11);
			player.cashAmount += 100;
			//money - collect $100
		}
		else if (randomCC == 12) 
		{
			print (cccard12);
			player.cashAmount -= 100;
			//money - pay $100
		}
		else if (randomCC == 13) 
		{
			print (cccard13);
			player.cashAmount -= 150;
			//money - pay $150
		}
		else if (randomCC == 14) 
		{
			print (cccard14);
			//money - Pay $40 per house and $115 per hotel
		}
		else if (randomCC == 15) 
		{
			print (cccard15);
			player.cashAmount += 10;
			//money - collect $10
		}
		else if (randomCC == 16) 
		{
			print (cccard16);
			player.cashAmount += 100;
			//money - collect $100
		}
		
	}
	

}
