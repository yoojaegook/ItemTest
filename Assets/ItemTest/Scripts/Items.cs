using UnityEngine;
public enum EItemTypes//아이템타입 이넘 
{
    Weapon,
    Amor,
    Ring
}
[System.SerializableAttribute]
public abstract class Items  {
    public int _invenNumber;//속하게될 인벤토리 번호
    public int _itemLevel=1;//아이템 레벨 
    public float _levelPerPropertyIncreasePersent;//레벨당 상승폭 
    public EItemTypes _type;//아이템타입
    public string _itemCode;//아이템코드
    public string _itemName;//아이템이름
    public Sprite _sprite;//아이템그림
    public abstract void Init();//아이템생성될때 함수 추상화 
    public virtual void LvUp()
    {
        _itemLevel++;
    }
}
