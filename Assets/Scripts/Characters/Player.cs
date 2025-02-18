using System;
using System.Collections.Generic;
using RPG.Character;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, ICharacteristic, IPrepared, IPickupable, ILevelable
{
    public float exp = 0;
    [SerializeField]
    private CharacterStatSAO _data;
    [SerializeField]
    private Stats _currentStats;
    [SerializeField]
    private Transform _thrown;
    [SerializeField]
    private HealthBar _healthBar;
    [SerializeField]
    private List<WeaponSAO> _handSlots = new();
    [SerializeField]
    private LevelManagerSAO _levelManagerSAO = null;
    [Space]
    [SerializeField]
    private UnityEvent onLevelUp = new();

    private Dictionary<string, IEquipable> _armourMap = new();

    #region PROPERTIES
    public int Level { get; private set; }
    public Stats CurrentStats => _currentStats;
    public CharacterStatSAO Data => _data;
    public Dictionary<string, IEquipable> ArmourMap => _armourMap;
    public List<IEquipable> HandSlots
    {
        get
        {
            List<IEquipable> result = new();
            foreach(WeaponSAO weaponSAO in _handSlots)
            {
                result.Add(weaponSAO);
            }
            return result;
        }
    }

    public LevelManagerSAO LevelManagerSAO => _levelManagerSAO;
    #endregion

    public void EquipArmour(int slotIndex)
    {
        throw new System.NotImplementedException();
    }

    public void EquipWeapons(int slotIndex, WeaponSAO weaponSAO)
    {
        if (_handSlots[slotIndex] != null)
        {
            _currentStats = _currentStats - _handSlots[slotIndex].Stats;
            _handSlots[slotIndex] = null;
        }
        _handSlots[slotIndex] = weaponSAO;
        _currentStats = _currentStats + _handSlots[slotIndex].Stats;
    }

    public void TakeDamage(float damageDeal)
    {
        _currentStats.health -= damageDeal;
        _healthBar.OnHealthChanged?.Invoke(_currentStats.health);
    }

    public void PickUp(DropItemSAO item, Action onPickupCallBack)
    {
        onPickupCallBack.Invoke();
        LevelUp();
    }

    public void LevelUp()
    {
        if (Level < _levelManagerSAO.Levels.Length && exp >= _levelManagerSAO.Levels[Level].MaxExp)
        {
            exp -= _levelManagerSAO.Levels[Level].MaxExp;
            Level++;
            onLevelUp?.Invoke();
        }
    }

    void Awake()
    {
        _currentStats = _data.Stats;
        _healthBar.Setup(_currentStats.health, _data.Stats.health);
    }

    void Update()
    {
        _currentStats.attackRate -= Time.deltaTime;
        if (_currentStats.attackRate <= 0)
        {
            foreach (WeaponSAO weaponSAO in _handSlots)
            {
                weaponSAO.Use(this, _thrown);
            }
            _currentStats.attackRate = _data.Stats.attackRate;
        }
    }
}
