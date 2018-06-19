using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionResponseScript : ScriptableObject
{
	public string requiredString;

	public abstract bool DoActionResponse(GameControllerScript gameController);

}
