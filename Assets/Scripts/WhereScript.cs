using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Where")]
public class WhereScript : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		gameController.roomNav.DisplayCurrentRoom();
	}

}
