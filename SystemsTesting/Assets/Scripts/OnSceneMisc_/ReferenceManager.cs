using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
	public static ReferenceManager instance;

	[SerializeField] public Transform screenCenterPoint;
	[SerializeField] public BuffItemPicker buffitemPicker;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
}
