using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnhancementItems
{
	Necklace,
	Ring,
	Boots,
	Helmet
}

[CreateAssetMenu(fileName = "New Buff Object", menuName = "ChestDropBuff/Buffs")]
public class BuffItem : ScriptableObject
{
	public string buffItemName;

	public GameObject buffItemIcon;
	public GameObject buffItemPrefab;

	public float damageIncrease;
	public float walkSpeedIncrease;
	public float sprintSpeedIncrease;
	public float abilityCooldownReduction;

	[TextArea(15, 20)]
	public string buffItemDescription;
}
