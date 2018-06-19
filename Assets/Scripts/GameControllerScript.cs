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
		// Effacement des anciens logs
		ClearCollectionsForNewRoom();

		// Preparation de la nouvelle room
		UnpackRoom();

		// Concatenation de toutes les interactions du player et des descriptions de la room
		string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());
		string combinedText                  = roomNav.currentRoom.description + "\n" + joinedInteractionDescriptions;

		// Affichage de tout le texte
		LogStringWithReturn(combinedText);
	}
	 

	/// <summary>
	/// Unpacks the room. Preparation de la nouvelle room
	/// </summary>
	private void UnpackRoom()
	{
		roomNav.UnpackExistsInRoom();
	}


	/// <summary>
	/// Clears the collections for new room. Nettoyage des textes lors d'un changement de room
	/// </summary>
	private void ClearCollectionsForNewRoom()
	{
		interactionDescriptionsInRoom.Clear();
		roomNav.ClearExits();
	}


	/// <summary>
	/// Logs the string with return. Ajoute du texte au log, puis l'affiche 
	/// </summary>
	/// <param name="stringToAdd">String to add.</param>
	public void LogStringWithReturn(string stringToAdd)
	{
		actionLog.Add(stringToAdd + "\n");
	}










}
