using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Create new item")]
public class ItemData : ScriptableObject
{
	public int id;
	public string itemName;

	[TextArea(3, 3)] public string itemDescription;

	public enum Types
	{
		Weaponry,
		KeyItems,
		Story
	}

	public GameObject itemPrefab;
	public Texture icon;

	public Types itemTypes;
	public int maxItemStack;
	public int baseValue;
	public int baseCost;

}

