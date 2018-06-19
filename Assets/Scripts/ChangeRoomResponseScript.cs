using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionReponses/ChangeRoom")]
public class ChangeRoomResponseScript : ActionResponseScript
{
	public RoomScript roomToChangeTo;


	public override bool DoActionResponse(GameControllerScript gameController)
	{
		if (gameController.roomNav.currentRoom.roomName == requiredString)
		{
			gameController.roomNav.currentRoom = roomToChangeTo;
			gameController.DisplayRoomText();
			return true;
		}

		return false;
	}

}
