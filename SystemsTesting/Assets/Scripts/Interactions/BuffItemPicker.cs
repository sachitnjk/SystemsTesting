using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItemPicker : MonoBehaviour
{
	public List<BuffItem> buffItemsList;

	[SerializeField] public int buffPickerCount;

	public void PickRandomBuff(int count)
	{
		List<BuffItem> pickeditems = new List<BuffItem>();

		while (pickeditems.Count < count)
		{
			int randomIndex = Random.Range(0, buffItemsList.Count);
			BuffItem item = buffItemsList[randomIndex];

			if(!pickeditems.Contains(item) ) 
			{
				pickeditems.Add(item);
			}
		}

		foreach (BuffItem item in pickeditems) 
		{
			Debug.Log(item.buffItemName);
		}
	}
}
