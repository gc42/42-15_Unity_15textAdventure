using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class GoScript : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		gameController.roomNav.AttemptToChangeRooms (separatedInputWords [1]);
	}

}
