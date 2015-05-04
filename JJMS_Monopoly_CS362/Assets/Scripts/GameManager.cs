using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	public GameObject focusPoint;
	public bool playersTurn = false;

	public bool gameReady = false;
	public bool gameOver = false;
	public bool cameraShifting = false;
	public bool cameraRotating = false;

	public bool freeRoamMode = false;

	public Vector3 cameraShiftDestination;

	public List <GameTile> gameBoard;//The list of lists of tiles
	public List <Player> players = new List<Player>();//list of all the players
	public List <GameObject> playerPieces;
	public Vector3 startPosition;
	public int currentCameraAngle;
	public bool chanceAction;



	public Card eventCards; 
	public Player activePlayer;

	private int currentIndex;

	void Awake()
	{
		
		instance = this;
		currentIndex = 0;

		startPosition = gameBoard [0].transform.position;
		transform.position = Vector3.zero;
		cameraShiftDestination = Vector3.zero;
		currentCameraAngle = 45;


		Player tempPlayer = ((GameObject)Instantiate (playerPieces[players.Count], startPosition, Quaternion.Euler (new Vector3 ()))).GetComponent<Player>();
		tempPlayer.playerName = "Josh";
		tempPlayer.playerColor = Color.blue;
		players.Add (tempPlayer);

		tempPlayer = ((GameObject)Instantiate (playerPieces[0], startPosition, Quaternion.Euler (new Vector3 ()))).GetComponent<Player>();
		tempPlayer.playerName = "Molly";
		tempPlayer.playerColor = Color.magenta;
		players.Add (tempPlayer);
		
		tempPlayer = ((GameObject)Instantiate (playerPieces[0], startPosition, Quaternion.Euler (new Vector3 ()))).GetComponent<Player>();
		tempPlayer.playerName = "Joe";
		tempPlayer.playerColor = Color.cyan;
		players.Add (tempPlayer);
		
		tempPlayer = ((GameObject)Instantiate (playerPieces[0], startPosition, Quaternion.Euler (new Vector3 ()))).GetComponent<Player>();
		tempPlayer.playerName = "Dr. Verma";
		tempPlayer.playerColor = Color.yellow;
		players.Add (tempPlayer);
		
		tempPlayer = ((GameObject)Instantiate (playerPieces[0], startPosition, Quaternion.Euler (new Vector3 ()))).GetComponent<Player>();
		tempPlayer.playerName = "Stephan";
		tempPlayer.playerColor = Color.red;
		players.Add (tempPlayer);

		activePlayer = players [0];
		chanceAction = false;



	

	}
	void Start()
	{
		GUIManager.instance.setLeaderBoard ();

	}

	
	void OnGUI()
	{

	}

	void Update()
	{

		if(Input.GetKeyUp(KeyCode.Space))
		{
			if(!freeRoamMode)
			{
				freeRoamMode = true;
				currentCameraAngle = GetComponent<SmoothRotate>().angle;
			}
			else
			{
				freeRoamMode = false;
				cameraShiftDestination = getCurrentPlayer().transform.position;
				GetComponent<SmoothRotate>().angle = currentCameraAngle;

			}
		}
		if(freeRoamMode)
		{
			if(Input.GetKeyUp (KeyCode.Q))
			{
				GetComponent<SmoothRotate>().angle -= 90;
			}
			if(Input.GetKeyUp (KeyCode.E))
			{
				GetComponent<SmoothRotate>().angle += 90;
			}
		}
		else
		{
			shiftCamera();
		
			//Camera.main.transform.LookAt (getCurrentPlayer ().transform.position);
		
		
		}
	}
	
	public void nextTurn()
	{
		GUIManager.instance.rollText1.text = "---";
		GUIManager.instance.rollText2.text = "---";
		chanceAction = false;
		currentIndex += 1;
		currentIndex %= players.Count;
		activePlayer = getCurrentPlayer ();
		cameraShiftDestination = activePlayer.transform.position;
		GUIManager.instance.rollDice.interactable = true;
		if(activePlayer.inJail)
		{
			GUIManager.instance.displayChancePanel = true;
			GUIManager.instance.updateChancePanel(activePlayer.playerName + " is in jail, you lose your turn!", 6);
			activePlayer.inJail = false;
		}
	
		//activePlayer.isTakingTurn = true;

	}

	
	Player makePlayer(Vector3 startPosition, int playerLoadNumber, int classIndex)
	{
		Player newPlayer = null;
		return newPlayer;
	}
	
	void generatePlayers()
	{

	}
	

	public void shiftCamera()
	{
		if (Vector3.Distance (cameraShiftDestination, focusPoint.transform.position) > 0.1f)
		{
			cameraShifting = true;
			//transform.position += (cameraShiftDestination - focusPoint.transform.position).normalized * 2.0f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, activePlayer.transform.position,5f* Time.deltaTime);
			
			if(Vector3.Distance (cameraShiftDestination, transform.position) <= 0.2f)
			{
				transform.position = cameraShiftDestination;
				cameraShifting = false;
			}
		}
		
		if(!activePlayer.isMoving)
		{
			if(activePlayer.currentTileIndex/10 == 0)
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = -45;
			}
			else if(activePlayer.currentTileIndex/10 == 1)
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = 45;
			}
			else if(activePlayer.currentTileIndex/10 == 2)
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = 135;
			}
			else
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = 225;
			}
		}

		
	}

	
	public void rotateCameraAssist(Vector3 location,Vector3 target)
	{
		if((transform.position.x != target.x) || (transform.position.z != target.z))
		{
			if((transform.position.x <= target.x) && (transform.position.z <= target.z))
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = 45;
			}
			else if((transform.position.x >= target.x) && (transform.position.z >= target.z))
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = 225;
			}
			else if((transform.position.x <= target.x) && (transform.position.z >= target.z))
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = 135;
			}
			else if((transform.position.x >= target.x) && (transform.position.z <= target.z))
			{
				GameManager.instance.GetComponent<SmoothRotate>().angle = 315;
			}
		}
	}

	public Player getCurrentPlayer()
	{
		return players[currentIndex];
	}

	public void moveTo(Player player, int boardIndex)
	{
		player.destinationTile = gameBoard [boardIndex];
		player.isMoving = true;
	}


}










