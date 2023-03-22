using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemInteraction : MonoBehaviour
{
	[SerializeField] Transform playerCam;
	[SerializeField] LayerMask itemLayerMask;
	PlayerInventoryHandler inventoryHandler;

	[SerializeField] PlayerInput _input;
	InputAction interactAction;

	[SerializeField] TextMeshProUGUI txt_HoveredItem;


	private void Start()
	{
		inventoryHandler = GetComponent<PlayerInventoryHandler>();
		interactAction = _input.actions["Interect"];
	}

	private void Update()
	{
		RaycastHit hit;

		if(Physics.Raycast(playerCam.position, playerCam.forward, out hit, 2, itemLayerMask))
		{
			if(!hit.collider.GetComponent<ItemObject>())
			{
				return;
			}

			txt_HoveredItem.text = $"Press F to pick up {hit.collider.GetComponent<ItemObject>().amount}x {hit.collider.GetComponent<ItemObject>().itemData.name}";

			if(interactAction.WasPressedThisFrame())
			{
				Debug.Log("Pickup was called");
				//inventoryHandler.PickUpItem(hit.collider.GetComponent<ItemObject>());
			}
		}
		else
		{
			txt_HoveredItem.text = string.Empty;
		}
	}
}