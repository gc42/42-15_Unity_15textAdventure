using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Help")]
public class HelpScript : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		gameController.roomNav.DisplayHelp();
	}

}