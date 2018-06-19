using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input action script. A scriptable object which holds code to execute when an action is needed.
/// We made the 'Go' action which allows us to change rooms. Other actions fallows.
/// </summary>
public abstract class InputActionScript : ScriptableObject
{
	public string keyWord;

	public abstract void RespondToInput(GameControllerScript gameController, string[] separatedInputWords);
}
