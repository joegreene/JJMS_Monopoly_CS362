using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	public GameObject TilePrefab;
	public GameObject dummyPrefab;
	public GameObject playerPrefab;
	public GameObject aiPlayer;
	public GameObject playerArcher;
	public GameObject aiArcher;
	public GameObject aiMage;
	public GameObject playerMage;
	public GameObject focusPoint;
	public bool playersTurn = false;

	public bool gameReady = false;
	public bool gameOver = false;
	public bool cameraShifting = false;
	public bool cameraRotating = false;

	public bool freeRoamMode = false;

	public Vector3 cameraShiftDestination;

	public List <GameTile> map;//The list of lists of tiles
	public List <Player> players = new List<Player>();//list of all the players

	void Awake()
	{

		instance = this;

	}

	
	void OnGUI()
	{

	}

	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Space))
		{
			freeRoamMode = !freeRoamMode;
		}
	}
	
	public void nextTurn()
	{

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

}










