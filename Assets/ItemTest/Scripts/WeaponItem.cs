using UnityEngine;
[System.SerializableAttribute]
public class WeaponItem : Items {
    public int _weaponAtk;//나중에 결정될 무기 공격력
	public int _minAtk;//최소공격력
    public int _maxAtk;//최대공격력
    public override void Init()
    {
        _weaponAtk = Random.Range(_minAtk,_maxAtk);//생성시 공격력 결정 
    }
    public override void LvUp()
    {
        base.LvUp();
        _weaponAtk = (int)(_weaponAtk*(1+_levelPerPropertyIncreasePersent*0.01));
    }
}
