using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager UIManagerInstance;

	[SerializeField] public GameObject inventoryPanel;
	[SerializeField] public TextMeshProUGUI textHoveredItem;
	public GameObject[] slotUI;

	private void Awake()
	{
		if(UIManagerInstance == null)
		{
			UIManagerInstance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		slotUI = new GameObject[12];
		for(int i = 0; i < slotUI.Length; i++)
		{
			slotUI[i] = inventoryPanel.transform.GetChild(i).gameObject;
		}
	}
}
