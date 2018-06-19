using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputActionScript : ScriptableObject
{
	public string keyWord;

	public abstract void RespondToInput(GameControllerScript gameController, string[] separatedInputWords);
}
