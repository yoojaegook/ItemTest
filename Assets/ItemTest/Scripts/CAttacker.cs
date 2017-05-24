using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAttacker : MonoBehaviour {

	CEquipment _equip;
	public Text _Dmg;
	float _jiugaeTime=0;

	// Use this for initialization
	void Start () {
		_equip = GetComponent<CEquipment>();
	}
	
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		//데미지 텍스트 일정시간후 사라지게함 
		_jiugaeTime -= Time.deltaTime;
		if (_jiugaeTime<0.01f)
		{
			TurnOffText();
		}
	}
	public void HitToTarget()
	{
		if (!_equip.IsEquipWeapon())
		{
			//장착된 아이템 없으면 무기없음 표시 
			_Dmg.text = "NoWeapon";
			_jiugaeTime = 1.0f;
			return;
		}
		_Dmg.text = "Damage : "+ DMG();
		_jiugaeTime = 2.0f;
	}

	string DMG()
	{
		WeaponItem weapon = _equip.GetWeapon();
		return weapon._weaponAtk.ToString();
	}
	/// <summary>
	/// 데미티 텍스트 청소 
	/// </summary>
	void TurnOffText()
	{
		_Dmg.text = "";
	}
}
