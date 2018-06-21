using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Quit")]
public class QuitScript : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		gameController.QuitTheGame();
	}

}