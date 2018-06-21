using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Room navigation script. Holds a reference to the current room and loads and unloads rooms as we move between them.
/// </summary>
public class RoomNavigationScript : MonoBehaviour
{
	public RoomScript currentRoom;

	GameControllerScript gameController;

	Dictionary<string, RoomScript> exitDictionary = new Dictionary<string, RoomScript>();




	private void Awake()
	{
		gameController = GetComponent<GameControllerScript>();
	}




	public void UnpackExitsInRoom()
	{
		for (int i = 0; i < currentRoom.exits.Length; i++)
		{
			exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
			gameController.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);

		}
	}

	/// <summary>
	/// Player attempt (tentative) to go to an other room
	/// </summary>
	/// <param name="directionName">Direction name.</param>
	public void AttemptToChangeRooms(string directionName)
	{
		// 
		if (exitDictionary.ContainsKey(directionName))
		{
			currentRoom = exitDictionary[directionName];
			gameController.LogStringWithReturn("You head off to the " + directionName);
			gameController.DisplayRoomText();
		}
		else
		{
			gameController.LogStringWithReturn("There is no path to the " + directionName);
		}
	}

	/// <summary>
	/// Delete all entries of the dictionary. Dictionary is empty for new uses.
	/// </summary>
	public void ClearExits()
	{
		exitDictionary.Clear();
	}

	public void DisplayCurrentRoom()
	{
		gameController.LogStringWithReturn("You are in the " + currentRoom + " room.");
	}

	public void DisplayHelp()
	{
		gameController.LogStringWithReturn(
			"Pour jouer, taper les commandes suivantes,\n" +
			"- <color=red>go direction</color> pour se deplacer,\n" +
			"- <color=red>examine objectname</color> pour avoir des informations sur les objets,\n" +
			"- <color=red>take objectname</color> pour ramasser l'objet,\n" +
			"- <color=red>use objectname</color> pour se servir de l'objet,\n" +
			"- <color=red>inventory</color> pour lister les objets ramasses,\n" +
			"- <color=red>where</color> pour savoir dans quelle 'room' on se trouve,\n" +
			"- <color=red>help</color> to display this tips," +
			"- <color=red>quit</color> to exit the game and close the window.");
	}



}
