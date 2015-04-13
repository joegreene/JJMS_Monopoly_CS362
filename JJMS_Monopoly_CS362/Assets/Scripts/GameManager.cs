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

	public Player activePlayer;

	private int currentIndex;

	void Awake()
	{

		instance = this;
		currentIndex = 0;
		startPosition = gameBoard [0].transform.position;
		cameraShiftDestination = Vector3.zero;
		currentCameraAngle = 0;


		Player tempPlayer = ((GameObject)Instantiate (playerPieces[players.Count], startPosition, Quaternion.Euler (new Vector3 ()))).GetComponent<Player>();
		players.Add (tempPlayer);

		activePlayer = players [0];

	}
	void Start()
	{


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
		}
	}
	
	public void nextTurn()
	{
		currentIndex += 1;
		currentIndex %= players.Count;
		activePlayer = getCurrentPlayer ();
		activePlayer.isTakingTurn = true;

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
			transform.position += (cameraShiftDestination - focusPoint.transform.position).normalized * 7.0f * Time.deltaTime;
			if(Vector3.Distance (cameraShiftDestination, transform.position) <= 0.3f)
			{
				transform.position = cameraShiftDestination;
				cameraShifting = false;
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










