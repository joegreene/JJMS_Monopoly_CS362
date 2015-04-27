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
	public int cashAmount; // Amount of money in the player's bank
	public GameObject token; // The token peice that the player has chosen to represent the player on the board
	public List<PropertyTile>
				propertiesOwned = new List<PropertyTile> ();
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
		if(cashAmount < 0)
		{
			GameManager.instance.players.Remove(this);
		}
		if(GameManager.instance.activePlayer == this)
		{
			Debug.Log ("IsMoving: " + isMoving + " IsTakingTurn: " + isTakingTurn);
			if(isTakingTurn)
			{
				int diceRoll = rollDice ();
				destinationTile = GameManager.instance.gameBoard[(currentTileIndex + diceRoll) % GameManager.instance.gameBoard.Count];
				
				
				currentTileIndex += diceRoll % GameManager.instance.gameBoard.Count;

				isMoving = true;
				isTakingTurn = false;

			}
			if(isMoving)
			{
				if(destinationTile.transform.position.x == GameManager.instance.gameBoard[0].transform.position.x || destinationTile.transform.position.x == GameManager.instance.gameBoard[10].transform.position.x)
				{
					transform.position = Vector3.MoveTowards(transform.position, new Vector3(destinationTile.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime);

					if(transform.position.x == destinationTile.transform.position.x)
					{
						transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, destinationTile.transform.position.z), Time.deltaTime);		
					}
				}
				else
				{
					transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, destinationTile.transform.position.z), Time.deltaTime);		

					if(transform.position.z == destinationTile.transform.position.z)
					{
						transform.position = Vector3.MoveTowards(transform.position, new Vector3(destinationTile.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime);
					}
				}

				if(Vector3.Distance(transform.position,destinationTile.transform.position) <= 0.25f)
				{	
					transform.position = destinationTile.transform.position;
					isMoving = false;
					destinationTile.PlayerLanded(this);

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
	public void AddPropertyTile(PropertyTile PropertyTileToBeAdded)
	{
		propertiesOwned.Add(PropertyTileToBeAdded);
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
		if(propertiesOwned.Contains(tileToCheck))
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