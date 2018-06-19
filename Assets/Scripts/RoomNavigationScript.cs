using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigationScript : MonoBehaviour
{
	public RoomScript currentRoom;
	GameControllerScript gameController;

	Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>(); // TODO:

	private void Awake()
	{
		gameController = GetComponent<GameControllerScript>();
	}

	public void UnpackExistsInRoom()
	{
		for (int i = 0; i < currentRoom.exits.Length; i++)
		{
			exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
			gameController.interactionDescriptionInRoom.Add(currentRoom.exits[i].exitDescription);
		}
	}


	public void AttemptToChangeRooms(string directionNoun)
	{
		if (exitDictionary.ContainsKey(directionNoun))
		{
			currentRoom = exitDictionary[directionNoun];
			gameController.LogStringWithReturn("You head off to the " + directionNoun);
			gameController.DisplayRoomText();
		}
		else
		{
			gameController.LogStringWithReturn("There is no path to the " + directionNoun);
		}
	}

	public void ClearExits()
	{
		exitDictionary.Clear();
	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
