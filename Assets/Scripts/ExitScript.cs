using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Exit script. A serialised class which holds a description of the exit and a reference to the next room
/// </summary>
[System.Serializable]
public class ExitScript
{
	public string keyString;
	public string exitDescription;
	public RoomScript valueRoom;
}
