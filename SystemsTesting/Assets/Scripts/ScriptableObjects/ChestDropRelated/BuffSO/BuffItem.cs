using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnhancementItems
{
	Necklace,
	Gear,
	Chains,
	Sword
}

[CreateAssetMenu(fileName = "New Buff Object", menuName = "ChestDropBuff/Buffs")]
public class BuffItem : ScriptableObject
{
	public string buffItemName;

	public EnhancementItems enhancementItems;
	public GameObject buffItemIcon;
	public GameObject buffItemPrefab;

	[TextArea(15, 20)]
	public string buffItemDescription;
}
