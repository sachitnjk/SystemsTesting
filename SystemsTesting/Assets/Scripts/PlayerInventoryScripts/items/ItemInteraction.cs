using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemInteraction : MonoBehaviour
{
	[SerializeField] Transform playerPos;
	[SerializeField] LayerMask itemLayerMask;
	PlayerInventoryHandler inventoryHandler;

	[SerializeField] PlayerInput _input;
	InputAction interactAction;

	TextMeshProUGUI txt_HoveredItem;
	private void Awake()
	{
		GameObject canvas = GameObject.Find("Canvas");
		txt_HoveredItem = canvas.GetComponentInChildren<TextMeshProUGUI>();
	}
	private void Start()
	{
		inventoryHandler = GetComponent<PlayerInventoryHandler>();
		_input = GetComponent<PlayerInput>();
		interactAction = _input.actions["Interact"];
	}

	private void Update()
	{
		RaycastHit hit;

		if (Physics.Raycast(playerPos.position, playerPos.forward, out hit, 2, itemLayerMask))
		{
			if (!hit.collider.GetComponent<ItemObject>())
			{
				Debug.Log("going here");
				return;
			}

			txt_HoveredItem.text = $"Press F to pick up {hit.collider.GetComponent<ItemObject>().amount}x {hit.collider.GetComponent<ItemObject>().itemData.name}";
			if (interactAction.WasPressedThisFrame())
			{
				Debug.Log("Pickup was called");
				inventoryHandler.PickUpItem(hit.collider.GetComponent<ItemObject>());
			}

		}
		else
		{
			txt_HoveredItem.text = string.Empty;
		}
	}
}
