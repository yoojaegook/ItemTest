using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPickUpItem : MonoBehaviour {
	CInventory _inven;
	// Use this for initialization
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		_inven = GetComponent<CInventory>();
	}

	public void PickUp(Items pickItem,GameObject Sender)
	{
		if (!_inven.IsInvenFull())
		{
			_inven.AddInven(pickItem);//인벤에 추가
			Destroy(Sender);//아이템상자 파괴 
		}
	}
}
