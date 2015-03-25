using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


public class Player : MonoBehaviour
{
	private string playerName; // Players name will default to Player 1,2,3,.... or, n amount of playhers
	// DO YOU WANT TO KEEP TRACK OF DEMONINATION OF BILLS I.E. $1, $5, $10, ...
	// if so...check out cashAmountTwo;
	private int cashAmount; // Amount of money in the player's bank
	private int[,] cashAmountTwo = new int [1, 7];
	public GameObject token; // The token peice that the player has chosen to represent the player on the board
	//private GameTile playerLocation; // PropertyTile that the player is currently one
	/* Associative array where the first slot keeps track of the properties owned by the second attribute is associated
* with the ammount houses and hotels the player has on that PropertyTile. I used an associative array in that it is easier to keep
* track of two items that are associated with one another but different data types. We can split the second attribute into a second
* dictionary where the first PropertyTile is number of houses and the second is the number of hotels. I wasnt to sure how houses and hotels
* going to be implented in this game, as and object or an attribute to the location.
*/
	// This Dictionary implies that the second attribute is associated with the number of houses and hotels and one number. Where 0 is neither
	// houses nor hotels are owned. 1, 2, and 3 represent the number of houses. 4 represents 1 hotel and 5 represents 2 hotels
	private IDictionary<PropertyTile, int>
		propertiesOwned = new Dictionary<PropertyTile, int>();
	// This Dictionary imples that the second attribute is associate witht the number of houses and hotels as two seperate entities in another
	// Dictionary. The first PropertyTile represents the number of house, the second represents the number of hotels.
	private IDictionary<PropertyTile, IDictionary<int, int>>
		propertiesOwned2 = new Dictionary<PropertyTile, IDictionary<int, int>>();
	//Default Constructor

	private List<PropertyTile> propertiesOwned3 = new List<PropertyTile>();
	public int currentTileIndex;
	public GameTile currentTile;
	public bool isTakingTurn;
	public bool isMoving;
	public GameTile destinationTile;

	void Start()
	{
		playerName = "Player 1";
		currentTile = GameManager.instance.gameBoard [0];
		currentTileIndex = 0;
		cashAmount = 1500;
		isTakingTurn = false;
		destinationTile = currentTile;
	}

	void Update()
	{
		if(GameManager.instance.activePlayer == this)
		{
			Debug.Log ("IsMoving: " + isMoving + " IsTakingTurn: " + isTakingTurn);
			if(isTakingTurn)
			{
				int diceRoll = rollDice ();
				destinationTile = GameManager.instance.gameBoard[(currentTileIndex + diceRoll) % GameManager.instance.gameBoard.Count];
				Debug.Log ((currentTileIndex + diceRoll) % GameManager.instance.gameBoard.Count);
				currentTileIndex += diceRoll % GameManager.instance.gameBoard.Count;
				isMoving = true;
				isTakingTurn = false;

			}
			if(isMoving)
			{
				transform.position = Vector3.MoveTowards(transform.position, destinationTile.transform.position, Time.deltaTime);
				if(Vector3.Distance(transform.position,destinationTile.transform.position) <= 0.25f)
				{
					transform.position = destinationTile.transform.position;
					isMoving = false;
				}
			}

		}
	}

	public string GetPlayerName()
	{
		return playerName;
	}

	public void SetPlayerName(string newPlayerName)
	{
		playerName = newPlayerName;
	}

	public int GetCashAmount()
	{
		return cashAmount;
	}
	public void SetCashAmount(int newCashAmount)
	{
		cashAmount = newCashAmount;
	}
	public void IncreaseCashAmount(int increaseCashByThisAmount)
	{
		cashAmount = cashAmount + increaseCashByThisAmount;
	}
	public void DecreaseCashAmount(int decreaseCashByThisAmount)
	{
		cashAmount = cashAmount - decreaseCashByThisAmount;
	}
	public int GetCashAmountTwo()
	{
		int total;
		total = cashAmountTwo[0, 0] + (cashAmountTwo[0, 1] * 5) + (cashAmountTwo[0, 2] * 10)
			+ (cashAmountTwo[0, 3] * 20) + (cashAmountTwo[0, 4] * 100) + (cashAmountTwo[0, 6] * 500);
		return total;
	}
	public void SetCashAmountTwo(int demoninationToChange, int newAmount)
	{
		cashAmountTwo[0, demoninationToChange] = newAmount;
	}
	public void AddPropertyTile(PropertyTile PropertyTileToBeAdded)
	{
		propertiesOwned.Add(PropertyTileToBeAdded, 0);
	}
	public void RemovePropertyTile(PropertyTile PropertyTileToBeRemoved)
	{
		propertiesOwned.Remove(PropertyTileToBeRemoved);
	}
	public GameTile GetPlayerLocation()
	{
		return currentTile;
	}
	public void SetPlayerLocation(PropertyTile newPlayerLocation)
	{
		currentTile = newPlayerLocation;
	}

	public bool OwnsProperty(PropertyTile tileToCheck)
	{
		if(propertiesOwned3.Contains(tileToCheck))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public int rollDice()
	{
		return Random.Range (2, 12);

	}
}