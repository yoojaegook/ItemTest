using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEquipment : MonoBehaviour {
	[SerializeField]bool _isEquipWeapon = false;
	public CInvenCell _equipWeapon;
	/// <summary>
	/// 무기장착 함수		
	/// </summary>
	/// <param name="weapon">아이템:무기타입 아이템</param>
	public void SetWeapon(CInvenCell cell)
	{
		_equipWeapon = cell;
		_isEquipWeapon = true;
	}
	/// <summary>
	/// 무기정보 가져오는 함수 
	/// </summary>
	/// <returns>현재 장착된 무기</returns>
	public WeaponItem GetWeapon()
	{
		return _equipWeapon._ownItem as WeaponItem;
	}
	/// <summary>
	/// 장비가 착용되어 있는지 검사(무기장착 체크함수)
	/// </summary>
	/// <returns></returns>
	public bool IsEquipWeapon()
	{
		return _isEquipWeapon;
	}
}
