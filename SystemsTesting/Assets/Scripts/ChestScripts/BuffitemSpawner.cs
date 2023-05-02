using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffitemSpawner : MonoBehaviour
{
	BuffItemPicker _buffitemPicker;

	[SerializeField] public Transform[] buffTransform;

	private void Start()
	{
		_buffitemPicker = GetComponent<BuffItemPicker>();
	}
}
