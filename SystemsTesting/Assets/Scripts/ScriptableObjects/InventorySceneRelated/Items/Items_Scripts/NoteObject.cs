using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Note Object", menuName = "Inventory System/Items/Note")]
public class NoteObject : ItemObject
{
	public void Awake()
	{
		type = ItemType.Note;
	}
}
