using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
public class UseScript : InputActionScript
{
	public override void RespondToInput(GameControllerScript gameController, string[] separatedInputWords)
	{
		gameController.interactableItems.UseItem(separatedInputWords);
	}
}
