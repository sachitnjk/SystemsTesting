using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryHandler : MonoBehaviour
{
	public Slots[] slots = new Slots[20];
	GameObject inventoryUI;

	PlayerInput _input;
	InputAction inventoryOpenClose;

	private void Awake()
	{
		GameObject canvas = GameObject.Find("Canvas");
		inventoryUI = canvas.GetComponentInChildren<Transform>().gameObject;

	}

	private void Start()
	{
		slots = inventoryUI.GetComponentsInChildren<Slots>();
		for (int i = 0; i < slots.Length; i++)
		{
			if(slots[i].itemsInSlot == null)
			{
				for(int k = 0; k < slots[i].transform.childCount; k++)
				{
					slots[i].transform.GetChild(k).gameObject.SetActive(false);
				}
			}
		}

		_input = GetComponent<PlayerInput>();
		inventoryOpenClose = _input.actions["Inventory"];
	}

	private void Update()
	{
		if(!inventoryUI.activeInHierarchy && inventoryOpenClose.WasPressedThisFrame())
		{
			inventoryUI.SetActive(true);
		}
		else if(inventoryUI.activeInHierarchy && inventoryOpenClose.WasPressedThisFrame())
		{
			inventoryUI.SetActive(false);
		}
	}

	public void PickUpItem(ItemObject itemObj)
	{
		for(int i =0; i < slots.Length; i++)
		{
			if (slots[i].itemsInSlot !=null && slots[i].itemsInSlot.id == itemObj.itemData.id && slots[i].amountInSlot != slots[i].itemsInSlot.maxItemStack)
			{
				if (!HitMaxStack(i, itemObj.amount))
				{
					slots[i].amountInSlot += itemObj.amount;
					Destroy(itemObj.gameObject);
					slots[i].SetStats();
					return;
				}
				else
				{
					int result = NeededToFill(i);
					itemObj.amount = RemainingAmount(i, itemObj.amount);
					slots[i].amountInSlot += result;
					slots[i].SetStats();
					PickUpItem(itemObj);
					return;
				}
			}
			else if (slots[i].itemsInSlot == null)
			{
				slots[i].itemsInSlot = itemObj.itemData;
				slots[i].amountInSlot = itemObj.amount;
				Destroy(itemObj.gameObject);
				slots[i].SetStats();
				return;
			}
		}
	}

	private bool HitMaxStack(int index, int amount)
	{
		if(slots[index].itemsInSlot.maxItemStack <= slots[index].amountInSlot + amount)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private int NeededToFill(int index)
	{
		return slots[index].itemsInSlot.maxItemStack - slots[index].amountInSlot;
	}

	private int RemainingAmount(int index, int amount)
	{
		return (slots[index].amountInSlot + amount) - slots[index].itemsInSlot.maxItemStack;
	}
}
