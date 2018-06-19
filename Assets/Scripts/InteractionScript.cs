using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractionScript
{
	public InputActionScript inputAction;
	[TextArea]
	public string textResponse;
	public ActionResponseScript actionResponse;
}
