using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Game controller script. Manage all the sub-systems of the game and the actionLog,
/// a list of strings which contains everything that has happened so far.
/// </summary>
public class GameControllerScript : MonoBehaviour
{
	
	public Text displayText;
	public InputActionScript[] inputActions;


	[HideInInspector] public RoomNavigationScript roomNav;
	[HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();
	[HideInInspector] public InteractableItemsScript interactableItems;

	List<string> actionLog = new List<string>();



	private void Awake()
	{
		interactableItems = GetComponent<InteractableItemsScript>();
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
		PrepareObjectsToTakeOrExamine(roomNav.currentRoom);
	}

	/// <summary>
	/// Prepares the objects to take or examine. 
	/// </summary>
	/// <param name="currentRoom">Current room.</param>
	void PrepareObjectsToTakeOrExamine(RoomScript currentRoom)
	{
		for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
		{
			string descriptNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);
			if (descriptNotInInventory != null)
			{
				interactionDescriptionsInRoom.Add(descriptNotInInventory);
			}

			InteractableObjectScript interactableInRoom = currentRoom.interactableObjectsInRoom[i];

			for (int j = 0; j < interactableInRoom.interactions.Length; j++)
			{
				InteractionScript interaction = interactableInRoom.interactions[j];
				if (interaction.inputAction.keyWord == "examine")
				{
					interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
				}

				if (interaction.inputAction.keyWord == "take")
				{
					interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
				}

			}

		}
	}


	public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
	{
		if (verbDictionary.ContainsKey(noun))
		{
			return verbDictionary[noun];
		}

		return "You can't " + verb + " " + noun;
	}


	/// <summary>
	/// Clears the collections for new room. Nettoyage des textes lors d'un changement de room
	/// </summary>
	private void ClearCollectionsForNewRoom()
	{
		interactableItems.ClearCollections();
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
