using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
	public ItemData itemsInSlot;
	public int amountInSlot;

	RawImage icon;
	TextMeshProUGUI txt_amount;

	public void SetStats()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}

		icon = GetComponent<RawImage>();
		txt_amount = GetComponent<TextMeshProUGUI>();

		icon.texture = itemsInSlot.icon;
		txt_amount.text = $"{amountInSlot}";
	}

}
