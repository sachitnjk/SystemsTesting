using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryCaller : MonoBehaviour
{
	public InventoryObject inventory;

	private void OnTriggerEnter(Collider other)
	{
		var item = other.GetComponent<ItemObjectCaller>();
		if(item)
		{
			inventory.AddItem(item.item, 1);
			Destroy(other.gameObject);
		}
	}

	private void OnApplicationQuit()
	{
		inventory.Container.Clear();
	}
}
