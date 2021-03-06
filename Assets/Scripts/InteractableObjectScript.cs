﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "TextAdventure/InteractableObject")]
public class InteractableObjectScript : ScriptableObject
{
	public string noun = "name";
	[TextArea]
	public string description = "description in room";
	public InteractionScript[] interactions;

}
