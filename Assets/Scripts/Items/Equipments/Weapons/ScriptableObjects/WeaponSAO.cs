using System.Collections.Generic;
using RPG.Item;
using RPG.Character;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class WeaponSAO : BaseItemSAO, IEquipable, IWeaponize, IUpgradable<WeaponSAO>
{
    [SerializeField]
    private Stats _stats;
    [SerializeField]
    private List<WeaponFunctionSAO> _functions = new();
    [SerializeField]
    private WeaponSAO _weaponSAO;

    #region PROPERTIES
    public Stats Stats => _stats;
    public WeaponSAO Upgradable => _weaponSAO;
    #endregion

    public void Use<T>(T owner, Transform spawnPosition) where T : MonoBehaviour, ICharacteristic
    {
        foreach (WeaponFunctionSAO weaponFunctionSAO in _functions)
        {
            weaponFunctionSAO.OnUsed(owner, spawnPosition);
        }
    }
}