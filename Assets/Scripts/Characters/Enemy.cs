using System.Collections.Generic;
using RPG.Character;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacteristic, IDropable
{
    [SerializeField]
    private CharacterStatSAO _data;
    [SerializeField]
    private DropItemSAO _dropItem;
    [SerializeField]
    private Stats _currentStats;

    public Stats CurrentStats => _currentStats;

    public CharacterStatSAO Data => _data;

    public Dictionary<string, IEquipable> ArmourMap => throw new System.NotImplementedException();

    public List<IEquipable> HandSlots => throw new System.NotImplementedException();

    public DropItemSAO DropItem => _dropItem;

    public void Drop()
    {
        _dropItem.Drop(transform.position);
    }

    public void EquipArmour(int slotIndex)
    {
        throw new System.NotImplementedException();
    }

    public void EquipWeapons(int slotIndex, WeaponSAO weaponSAO)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damageDeal)
    {
        _currentStats.health -= damageDeal;
    }
}