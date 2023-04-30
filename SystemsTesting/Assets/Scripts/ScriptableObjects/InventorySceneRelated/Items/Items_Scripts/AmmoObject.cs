using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo Object", menuName = "Inventory System/Items/Ammo")]

public class AmmoObject : ItemObject
{
	public int ammoInBox;
	private void Awake()
	{
		type = ItemType.Ammo;
	}
}
