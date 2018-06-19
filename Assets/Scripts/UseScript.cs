using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
public class Use : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		gameController.interactableItems.UseItem(separatedInputWords);
	}
}
