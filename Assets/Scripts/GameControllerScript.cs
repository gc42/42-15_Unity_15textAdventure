using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
	public Text displayText;
	public InputActionScript[] inputActions;

	[HideInInspector] public RoomNavigationScript roomNav;
	[HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();

	List<string> actionLog = new List<string>();

	private void Awake()
	{
		roomNav = GetComponent<RoomNavigationScript>();
	}





	// Use this for initialization
	void Start ()
	{
		DisplayRoomText();
		DisplayLoggedText();
	}


	public void DisplayLoggedText()
	{
		string logAsText = string.Join("\n", actionLog.ToArray());

		displayText.text = logAsText;
	}



	public void DisplayRoomText()
	{
		ClearCollectionsForNewRoom();

		UnpackRoom();

		string joinedInteractionDescription = string.Join("\n", interactionDescriptionsInRoom.ToArray());

		string combinedText = roomNav.currentRoom.description + "\n" + joinedInteractionDescription;

		LogStringWithReturn(combinedText);
	}



	void UnpackRoom()
	{
		roomNav.UnpackExistInRoom();
	}



	void ClearCollectionsForNewRoom()
	{
		interactionDescriptionsInRoom.Clear();
		roomNav.ClearExits();
	}

	public void LogStringWithReturn(string stringToAdd)
	{
		actionLog.Add(stringToAdd + "\n");
	}










}
