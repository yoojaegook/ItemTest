using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CInvenCell : MonoBehaviour {

	CEquipment _equip;
	CInventory _inven;

	public Image _doSelect;
	public Image _itemImage;
	public Text _levelText;

	public Items _ownItem;

    public int _cellIndex;
	bool _isSelected = false;
	bool _isEmpty = true;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		_inven = GameObject.FindWithTag("Player").GetComponent<CInventory>();
		_equip = GameObject.FindWithTag("Player").GetComponent<CEquipment>();
	}
	public void DoSelect()
	{
		if (!IsEmpty())
		{
			Debug.Log("change");
			_inven.TurnOffDeSelectedCell(_ownItem._invenNumber,_ownItem);//인벤토리를 통해서 현재셀만 선택표시를 요청한다.
			ChangeEquiptment(_ownItem);//장비 바꾸는 함수 
		}
	}

	public void DeSelect()
	{
        _doSelect.enabled = false;
	}
	public void Defaulting()
	{
		_isEmpty = false;//비웠다는 표시 
		_itemImage.sprite = null;//그림 지우고 
		_itemImage.color = new Color(1,1,1,0);//투명하게 만들고 
		_ownItem = null;//아이템 비우고
	}
	/// <summary>
	/// 인벤칸에 아이템장착하고 숫자 설정하고 스프라이트 맞추고 아이템 스프라이트 키기
	/// </summary>
	/// <param name="items"></param>
	public void SetInvenCell(Items items)
	{
		_isEmpty = false;
		_cellIndex = items._invenNumber;
		_itemImage.sprite = items._sprite;
		_levelText.text = items._itemLevel.ToString();
		_itemImage.color = new Color(1, 1, 1, 1);
		_ownItem = items;
		CheckEquiptment(items);
	}
	public void CheckEquiptment(Items items)
	{
		switch (items._type)
		{
			case EItemTypes.Weapon ://아이템타입이 무기일때 
			if(!_equip.IsEquipWeapon())
				WeaponSet();
			break;
			default:
			break;
		}
	}
	public void ChangeEquiptment(Items items)
	{
		//아이템 타입에 따라서 장비변경
		switch (items._type)
		{
			case EItemTypes.Weapon : 
				WeaponSet();
			break;
			default:
			break;
		}
	}
    public void LevelUp()
    {
		//아이템 레벨 상승
		_ownItem.LvUp();
        _levelText.text = _ownItem._itemLevel.ToString();
    }
	//장비 클래스에 인벤칼을 통채로 넘긴다.
	void WeaponSet()
	{
		_equip.SetWeapon(this);
		_doSelect.enabled = true;
	}
	public bool IsEmpty()
	{
		return _isEmpty;
	}
	public bool IsSelected()
	{
		return _isSelected;
	}
}
