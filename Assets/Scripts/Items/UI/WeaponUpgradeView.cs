using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponUpgradeView : BaseItemView
{
    private Player _player;

    [SerializeField]
    private TMP_Text _name;
    [SerializeField]
    private TMP_Text _description;
    [SerializeField]
    private Button _upgrade;
    [Space]
    [SerializeField]
    private UnityEvent<WeaponSAO> onUpgrade = new();

    public UnityEvent<WeaponSAO> OnUpgrade => onUpgrade;

    public override void Setup(BaseItemSAO baseItemSAO)
    {
        base.Setup(baseItemSAO);
        _name.text = baseItemSAO.Name;
        _description.text = baseItemSAO.Description;
    }

    private void Upgrade()
    {
        if (baseItemSAO is not WeaponSAO)
        {
            return;
        }

        int index = -1;
        WeaponSAO weaponSAO = baseItemSAO as WeaponSAO;
        for (int i = 0; i < _player.HandSlots.Count; i++)
        {
            if (_player.HandSlots[i] is WeaponSAO equipedWeapon)
            {
                if (weaponSAO == equipedWeapon)
                {
                    if (equipedWeapon.Upgradable != null)
                    {
                        _player.EquipWeapons(i, equipedWeapon.Upgradable);
                        onUpgrade?.Invoke(equipedWeapon);
                    }
                    return;
                }
            }
            else if (_player.HandSlots[i] == null)
            {
                index = i;
            }
        }

        if (index != -1)
        {
            Debug.Log("Slot full!!!");
            return;
        }
        _player.EquipWeapons(index, weaponSAO);
    }


    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _upgrade.onClick.AddListener(Upgrade);
    }
}