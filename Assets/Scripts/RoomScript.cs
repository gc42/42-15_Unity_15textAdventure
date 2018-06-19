using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Room script. A scriptable object that holds a description of the room and a set of exits
/// </summary>
[CreateAssetMenu (menuName = "TextAdventure/Room")]
public class RoomScript : ScriptableObject
{

	[TextArea]
	public string description;
	public string roomName;
	public ExitScript[] exits;

	public InteractableObjectScript[] interactableObjectsInRoom;

}
