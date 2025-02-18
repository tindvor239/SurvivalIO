using UnityEngine;
using System.Collections.Generic;

public class LevelUpPopup : MonoBehaviour
{
    [SerializeField]
    private List<WeaponSAO> _levelUpWeapons = new();
    [SerializeField]
    private List<WeaponUpgradeView> _weaponUpgradeViews = new();
    [SerializeField]
    private Animation _animation;

    private List<WeaponSAO> _tempWeapons = new();

    public void Show()
    {
        _animation["ShowWindow"].speed = Time.unscaledTime;
        _animation.Play("ShowWindow");
        Time.timeScale = 0;
        List<WeaponSAO> randomUpgradeWeapons = new();
        for (int i = 0; i < (_levelUpWeapons.Count > 3 ? 3 : _levelUpWeapons.Count); i++)
        {
            int randomIndex = Random.Range(0, _levelUpWeapons.Count);
            Debug.Log(randomIndex);
            WeaponSAO weaponSAO = _levelUpWeapons[randomIndex];
            _tempWeapons.Add(weaponSAO);
            _levelUpWeapons.RemoveAt(randomIndex);

            if (weaponSAO.Upgradable == null)
            {
                if (_levelUpWeapons.Count > 0)
                {
                    i--;
                    continue;
                }
                return;
            }
            randomUpgradeWeapons.Add(weaponSAO);
        }

        foreach (WeaponSAO tempWeapon in _tempWeapons)
        {
            _levelUpWeapons.Add(tempWeapon);
        }
        _tempWeapons.Clear();

        if (randomUpgradeWeapons.Count == 0)
        {
            Close();
        }

        for (int i = 0; i < _weaponUpgradeViews.Count; i++)
        {
            _weaponUpgradeViews[i].gameObject.SetActive(i < randomUpgradeWeapons.Count);
            if (i < randomUpgradeWeapons.Count)
            {
                int index = i;
                _weaponUpgradeViews[i].Setup(randomUpgradeWeapons[i]);
                _weaponUpgradeViews[i].OnUpgrade.RemoveListener(OnUpgrade);
                _weaponUpgradeViews[i].OnUpgrade.AddListener(OnUpgrade);
            }
        }
    }

    public void Close()
    {
        Time.timeScale = 1f;
        _animation["CloseWindow"].speed = Time.unscaledTime;
        _animation.Play("CloseWindow");
    }

    private void OnUpgrade(WeaponSAO weaponSAO)
    {
        int index = _levelUpWeapons.IndexOf(weaponSAO);
        if (weaponSAO.Upgradable != null)
        {
            if (weaponSAO.Upgradable.Upgradable == null)
            {
                _levelUpWeapons.RemoveAt(index);
            }
            else
            {
                _levelUpWeapons[index] = weaponSAO.Upgradable;
            }
        }
    }
}
