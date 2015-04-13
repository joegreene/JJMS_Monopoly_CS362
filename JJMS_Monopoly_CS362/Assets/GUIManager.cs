using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	public Image purchasePanel;
	public Text purchasePrompt;
	public Button purchaseConfirm;
	public Button purchaseDeny;
	public bool displayPurchasePanel;
	public static GUIManager instance;



	// Use this for initialization
	void Start () 
	{
		displayPurchasePanel = false;
		purchasePanel.rectTransform.localScale = Vector2.zero;
		purchasePanel.rectTransform.anchoredPosition = Vector2.zero;
		instance = this;

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
	}

	public void confirmButtonAction()
	{
		displayPurchasePanel = false;
		Player tempPlayer = GameManager.instance.activePlayer;
		PropertyTile tempTile = (PropertyTile)GameManager.instance.gameBoard [tempPlayer.currentTileIndex];
		if(tempPlayer.cashAmount >= tempTile.propertyCost)
		{
			tempPlayer.AddPropertyTile (tempTile);
			tempPlayer.DecreaseCashAmount(tempTile.propertyCost);
		}
		else
		{
			Debug.Log ("Cant afford this!");
		}
		


	}

	public void denyButtonAction()
	{
		displayPurchasePanel = false;
	}

	public void rollDiceAction()
	{
		GameManager.instance.activePlayer.isTakingTurn = true;
	}
}
