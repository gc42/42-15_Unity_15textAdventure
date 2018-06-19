using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "TextAdventure/Room")]
public class RoomScript : ScriptableObject {

	[TextArea]
	public string description;
	public string roomName;
	public ExitScript[] exists;

}
