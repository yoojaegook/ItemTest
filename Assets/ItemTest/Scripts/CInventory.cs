using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInventory : MonoBehaviour {

	
	public GameObject[] _invenCells = new GameObject[6];
	public List<GameObject> _invenCellsList = new List<GameObject>();
	int _amountItems = 0;
	// Use this for initialization
	/// <summary>
	/// 인벤에 아이템 넣는다
	/// </summary>
	/// <param name="pickedItem"></param>
	public void AddInven(Items pickedItem)
	{
		for (int i = 0; i < _invenCells.Length; i++)
		{
            WeaponItem weapon = pickedItem as WeaponItem;
			Debug.Log(weapon._weaponAtk);
			if (_invenCells[i].GetComponent<CInvenCell>().IsEmpty())//비어있는칸에
			{
				pickedItem._invenNumber = i;
				_invenCells[i].SendMessage("SetInvenCell",pickedItem);
				_amountItems++;
				return;
			}
		}
	}
	/// <summary>
	/// 인벤이 가득찼는지 검사 
	/// </summary>
	/// <returns></returns>
	public bool IsInvenFull()
	{
		return _amountItems.Equals(_invenCells.Length)?true:false;//가득찼는지 검사 
	}
	/// <summary>
	/// 선택된 칸 이외에는 선택 이미지 끄기 
	/// </summary>
	/// <param name="index">보내는 셀 번호</param>
	/// <param name="cellItem">보내는 셀 아이템정보</param>
	public void TurnOffDeSelectedCell(int index,Items cellItem)
	{
		for (int i = 0; i < _invenCells.Length; i++)
		{
			if(i == index)//아이템 칸 번호와 인벤 셀 번호가 같은지 검사 
			continue;
			else
			{
				CInvenCell cell = _invenCells[i].GetComponent<CInvenCell>();
				if(!cell.IsEmpty()&&cell._ownItem._type.Equals(cellItem._type))//넘겨받은 아이템 타입과 검사하는 아이템 타입이 같은지 검사 
				{
					cell.DeSelect();
				}
			}
		}
	}
}
