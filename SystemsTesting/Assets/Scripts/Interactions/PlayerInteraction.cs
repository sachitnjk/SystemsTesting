using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField] float interactionDistance;
	[SerializeField] LayerMask aimLayer;

	[SerializeField] StarterAssetsInputs _input;

	private void Start()
	{
	}
	private void Update()
	{
		if(_input._InteractInput.WasPerformedThisFrame())
		{
			InteractableCheck();
		}
	}

	private void InteractableCheck()
	{
		Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
		Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
		if(Physics.Raycast(ray, out RaycastHit hitInfo, 999f, aimLayer)) 
		{
			if(hitInfo.collider.CompareTag("Interactable"))
			{
				Debug.Log("Interactable object");
			}
		}
	}

}
