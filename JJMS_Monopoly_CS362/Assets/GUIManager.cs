using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	public Image purchasePanel;
	public Image housePanel;
	public Image rentPanel;
	public Image chancePanel;

	public Transform playerFitter;
	public Image playerPanel;

	public PlayerGroup playerGroup;


	public Text purchasePrompt;
	public Text payRentPrompt;
	public Text purchaseHousePrompt;
	public Text chanceText;
	public Text rollText1;
	public Text rollText2;

	public Button purchaseConfirm;
	public Button purchaseDeny;
	public Button confirmRent;
	public Button rollDice; 
	public Button confirmChance;

	public Button purchaseHouseButton;
	public Button closePurchasePanel;


	public bool displayPurchasePanel;
	public bool displayRentPanel;
	public bool displayHousePanel;
	public bool displayChancePanel;

	public static GUIManager instance;

	void Awake()
	{
		instance = this;
	}


	// Use this for initialization
	void Start () 
	{
		displayPurchasePanel = false;
		purchasePanel.rectTransform.localScale = Vector2.zero;
		purchasePanel.rectTransform.anchoredPosition = Vector2.zero;

		displayHousePanel = false;
		housePanel.rectTransform.anchoredPosition = Vector2.zero;
		housePanel.rectTransform.localScale = Vector2.zero;

		displayRentPanel = false;
		rentPanel.rectTransform.anchoredPosition = Vector2.zero;
		rentPanel.rectTransform.localScale = Vector2.zero;

		
		displayChancePanel = false;
		chancePanel.rectTransform.anchoredPosition = Vector2.zero;
		chancePanel.rectTransform.localScale = Vector2.zero;
		



	}
		
	// Update is called once per frame
	void Update () 
	{
	
		if(displayPurchasePanel)
		{
			purchasePanel.rectTransform.localScale = 
				Vector2.Lerp(purchasePanel.rectTransform.localScale, 
				new Vector2(1.0f,1.0f),
				Time.deltaTime*5);
		}
		else
		{
			purchasePanel.rectTransform.localScale = 
				Vector2.Lerp(purchasePanel.rectTransform.localScale, 
				new Vector2(0f,0f),
				Time.deltaTime*5);
		}

		if(displayHousePanel)
		{
			housePanel.rectTransform.localScale = 
				Vector2.Lerp(housePanel.rectTransform.localScale, 
				             new Vector2(1.0f,1.0f),
				             Time.deltaTime*5);
		}
		else
		{
			housePanel.rectTransform.localScale = 
				Vector2.Lerp(housePanel.rectTransform.localScale, 
				             new Vector2(0f,0f),
				             Time.deltaTime*5);
		}

		if(displayRentPanel)
		{
			rentPanel.rectTransform.localScale = 
				Vector2.Lerp(rentPanel.rectTransform.localScale, 
				             new Vector2(1.0f,1.0f),
				             Time.deltaTime*5);
		}
		else
		{
			rentPanel.rectTransform.localScale = 
				Vector2.Lerp(rentPanel.rectTransform.localScale, 
				             new Vector2(0f,0f),
				             Time.deltaTime*5);
		}

		if(displayChancePanel)
		{
			chancePanel.rectTransform.localScale = 
				Vector2.Lerp(chancePanel.rectTransform.localScale, 
				             new Vector2(1.0f,1.0f),
				             Time.deltaTime*5);
		}
		else
		{
			chancePanel.rectTransform.localScale = 
				Vector2.Lerp(chancePanel.rectTransform.localScale, 
				             new Vector2(0f,0f),
				             Time.deltaTime*5);
		}

	}

	public void confirmButtonAction()
	{
		displayPurchasePanel = false;
		Player tempPlayer = GameManager.instance.activePlayer;
		PropertyTile tempTile = (PropertyTile)GameManager.instance.gameBoard [tempPlayer.currentTileIndex];
		tempPlayer.AddPropertyTile (tempTile);
		tempPlayer.DecreaseCashAmount(tempTile.propertyCost);
		tempTile.owner = tempPlayer;
		ParticleSystem temp = (ParticleSystem)Instantiate (tempPlayer.playerIdentifier, tempTile.transform.position + 0.02f * Vector3.up, Quaternion.Euler(-90.0f,0.0f,0.0f));
		temp.startColor = tempPlayer.playerColor;

		GameManager.instance.nextTurn ();
		rollDice.interactable = true;
		
		


	}

	public void confirmRentAction()
	{
		displayRentPanel = false;
		GameManager.instance.nextTurn();
		rollDice.interactable = true;

	}

	public void denyButtonAction()
	{
		displayPurchasePanel = false;
		GameManager.instance.nextTurn();
		rollDice.interactable = true;
	}

	public void rollDiceAction()
	{
		GameManager.instance.activePlayer.isTakingTurn = true;
		GameManager.instance.activePlayer.takeTurn();
		
		rollDice.interactable = false;
		//GameManager.instance.cameraShiftDestination = getCurrentPlayer ().transform.position;
	}

	public void updatePurchasePanel(PropertyTile pTile)
	{
		if(GameManager.instance.activePlayer.cashAmount > pTile.propertyCost)
		{
			purchasePrompt.text = "Would you like to purchase: " + pTile.tileName + " for $" + pTile.propertyCost + "?";
			purchaseConfirm.interactable = true;
		}
		else
		{
			purchasePrompt.text = "You do not have enough money to purchase this property...";
			purchaseConfirm.interactable = false;
		}
	}

	public void updateRentPanel(PropertyTile pTile, Player owner, Player landed)
	{
		payRentPrompt.text = landed.GetPlayerName ()+ " landed on a property tile owned by " + owner.GetPlayerName() + " You must pay $" + pTile.CalculateRent()+ " in rent!";
	}
	public void updateHousePanel(PropertyTile pTile, Player player)
	{
		purchaseHouseButton.interactable = true;
		if(pTile.numHouses > 4)
		{
			purchaseHousePrompt.text = "This property has been fully upgraded, enjoy your stay!";
			purchaseHouseButton.interactable = false;
		}
		else
		{
			if(player.cashAmount > pTile.houseCost)
			{
				if(pTile.numHouses > 0)
				{
					purchaseHousePrompt.text = "You, currently have " + pTile.numHouses + " on this property. Would you like to purchase another house for $" + pTile.houseCost + "?";
					if(pTile.numHouses == 4 && player.cashAmount > pTile.houseCost*5)
					{
						purchaseHousePrompt.text ="Would you like to upgrade to a hotel for $"+ (pTile.houseCost*5) +" ?";
					}
					else
					{
						purchaseHousePrompt.text ="Unfortunately, you do not have enough money to purchase a hotel...";
						purchaseHouseButton.interactable = false;
					}
				}
				else
				{
					purchaseHousePrompt.text = "Would you like to purchase a house on this property for $"+ pTile.houseCost+"?";
				}
			}
			else
			{
				purchaseHousePrompt.text ="Unfortunately, you do not have enough money to purchase a house...";
				purchaseHouseButton.interactable = false;
			}
		}

	}
	public void updateChancePanel(string chanceMessage, int eventIndex)
	{
		switch (eventIndex)
		{
			case 0:
			{
				chanceText.text = "CHANCE CARD!\n";
				chanceText.text += chanceMessage;
				break;
			}
			case 1:
			{
				chanceText.text ="COMMUNITY CHEST!\n";
				chanceText.text += chanceMessage;
				break;
			}
			case 2:
			{
				chanceText.text = chanceMessage;
				break;
			}
			case 3:
			{
				chanceText.text = chanceMessage;
				break;
			}
			case 4:
			{
				chanceText.text = chanceMessage;
				break;
			}
			case 5:
			{
				chanceText.text = chanceMessage;
				GameManager.instance.chanceAction = false;
				break;	
			}
			case 6:
			{
				chanceText.text = chanceMessage;
				GameManager.instance.chanceAction = false;
				break;	
			}
			default:
			{
				break;
			}
		}

	}

	public void purchaseHouseButtonAction()
	{

		Player tempPlayer = GameManager.instance.activePlayer;
		PropertyTile tempTile = (PropertyTile)GameManager.instance.gameBoard [tempPlayer.currentTileIndex];
		if(tempPlayer.cashAmount >= tempTile.propertyCost)
		{
			if(tempTile.numHouses < 4)
			{
				tempPlayer.DecreaseCashAmount(tempTile.houseCost);
				tempTile.numHouses += 1;
			}
			else
			{
				tempPlayer.DecreaseCashAmount(tempTile.houseCost * 5);
				tempTile.numHouses += 1;
			}
		}
		displayHousePanel = false;
		rollDice.interactable = true;
		GameManager.instance.nextTurn();
	}
	public void closeHouseButtonAction()
	{
		displayHousePanel = false;
		rollDice.interactable = true;
		GameManager.instance.nextTurn();
	}

	public void chanceButtonAction()
	{
		Debug.Log ("Closing dat shit");
		displayChancePanel = false;
		rollDice.interactable = true;
		if(!GameManager.instance.chanceAction)
		{
			GameManager.instance.nextTurn();
		}
	}

	public void setLeaderBoard ()
	{
		foreach (Player player in GameManager.instance.players) {
			PlayerGroup temp = (PlayerGroup)Instantiate (playerGroup, playerFitter.position, playerFitter.rotation);
			temp.transform.SetParent (playerFitter, false);
			temp.transform.localScale = Vector3.one;
			temp.init (player);
		}
	}

}
