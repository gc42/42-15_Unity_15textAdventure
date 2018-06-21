using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class GoScript : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		// Sur le principe "verbe, action" comme 'go north', on va chercher le deuxieme mot [1] du user separated input in words
		gameController.roomNav.AttemptToChangeRooms (separatedInputWords [1]);
	}

}
