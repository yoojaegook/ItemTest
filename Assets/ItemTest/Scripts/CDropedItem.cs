using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDropedItem : MonoBehaviour {
	public List<WeaponItem> _haveItems = new List<WeaponItem>();

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other);
		if (other.tag.Equals("Player"))
		{
			CPickUpItem pickup = other.transform.GetComponent<CPickUpItem>();//플레이어 픽업찾기 
			Items dropItem = _haveItems[Random.Range(0, _haveItems.Count)];//드롭아이템 랜덤선택 
			dropItem.Init();//아이템 생성함수 실행 
			pickup.PickUp(dropItem,this.gameObject);//픽업클래스에서 픽업함수 실행 
		}
	}
}
