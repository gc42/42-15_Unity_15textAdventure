using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemsScript : MonoBehaviour
{
	public List<InteractableObjectScript> usableItemList;

	// NOTA:  Dictionaries cannot be displayed in the Inspector, because they are non ordered lists
	public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
	public Dictionary<string, string> takeDictionary    = new Dictionary<string, string>();
	[HideInInspector] public List<string> nounsInRoom = new List<string>();
	private Dictionary<string, ActionResponseScript> useDictionary = new Dictionary<string, ActionResponseScript>(); //
	public List<string> nounsInInventory = new List<string>();
	private GameControllerScript gameController;


	public string GetObjectsNotInInventory(RoomScript currentRoom, int i)
	{
		InteractableObjectScript interactableInRoom = currentRoom.interactableObjectsInRoom[i];

		if (!nounsInInventory.Contains (interactableInRoom.noun))
		{
			nounsInRoom.Add(interactableInRoom.noun);

			return interactableInRoom.description;
		}

		return null;
	}

	private void Awake()
	{
		gameController = GetComponent<GameControllerScript>();
	}

	public void AddActionResponsesToUseDictionary()
	{
		for (int i = 0; i < nounsInInventory.Count; i++)
		{
			string noun = nounsInInventory[i];

			InteractableObjectScript interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
			if (interactableObjectInInventory == null)
			{
				continue;
			}

			for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
			{
				InteractionScript interaction = interactableObjectInInventory.interactions[j];

				if (interaction.actionResponse == null)
				{
					continue;
				}

				if (!useDictionary.ContainsKey(noun))
				{
					useDictionary.Add(noun, interaction.actionResponse);
				}
			}


		} 
	}

	private InteractableObjectScript GetInteractableObjectFromUsableList(string noun)
	{
		for (int i = 0; i < usableItemList.Count; i++)
		{
			if (usableItemList[i].noun == noun)
			{
				return usableItemList[i];
			}
		}
		return null;
	}



	/// <summary>
	/// Displaies the inventory. List all objects the player have in his inventory
	/// </summary>
	public void DisplayInventory()
	{
		gameController.LogStringWithReturn("You look in your backpack, inside you have: ");

		for (int i = 0; i < nounsInInventory.Count; i++) 
        {
			gameController.LogStringWithReturn(nounsInInventory[i]);
		}
	}

	/// <summary>
	/// Clears the collections before entering in a new room
	/// </summary>
	public void ClearCollections()
	{
		examineDictionary.Clear();
		takeDictionary.Clear();
		nounsInRoom.Clear();
	}

	public Dictionary<string, string> Take(string[] separatedInputWords)
	{
		string noun = separatedInputWords[1];

		if (nounsInRoom.Contains(noun))
		{
			nounsInInventory.Add(noun);
			nounsInRoom.Remove(noun);
			AddActionResponsesToUseDictionary();
			return takeDictionary;
		}
		else
		{
			gameController.LogStringWithReturn("There is no " + noun + " here to take.");
			return null;
		}
	}


    public void UseItem(string[] separatedInputWords)
	{
		string nounToUse = separatedInputWords[1];

		// Check if the noun is in the inventory
		if (nounsInInventory.Contains(nounToUse))
		{ 
			// Check if the key is in the inventory
			if (useDictionary.ContainsKey(nounToUse))
			{
				bool actionResult = useDictionary[nounToUse].DoActionResponse(gameController);
				if (actionResult == false)
				{
					gameController.LogStringWithReturn("Hmm. Nothing happens.");
				}
			}
			else
			{
				gameController.LogStringWithReturn("You can't use the " + nounToUse);
			}
		}
		else
		{
			gameController.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use");
		}
	}

}
