using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]
public class ExamineScript : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		gameController.LogStringWithReturn(gameController.TestVerbDictionaryWithNoun(gameController.interactableItems.examineDictionary, separatedInputWords[0], separatedInputWords[1]));
	}

}
