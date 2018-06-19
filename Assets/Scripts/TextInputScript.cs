using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInputScript : MonoBehaviour
{
	public InputField inputField;
	GameControllerScript gameController;

	private void Awake()
	{
		gameController = GetComponent<GameControllerScript>();
		inputField.onEndEdit.AddListener(AcceptStringInput);
	}



	void AcceptStringInput(string userInput)
	{
		userInput = userInput.ToLower();
		gameController.LogStringWithReturn(userInput);

		char[] delimiterCharacters = { ' ' };
		string[] separatedInputWords = userInput.Split(delimiterCharacters);

		for (int i = 0; i < gameController.inputActions.Length; i++)
		{
			InputActionScript inputAction = gameController.inputActions[i];
			if (inputAction.keyWord == separatedInputWords [0])
			{
				inputAction.RespondToInput(gameController, separatedInputWords);
			}
		}

		InputComplete();
	}


	void InputComplete()
	{
		gameController.DisplayLoggedText();
		inputField.ActivateInputField();
		inputField.text = null;
	}
}
