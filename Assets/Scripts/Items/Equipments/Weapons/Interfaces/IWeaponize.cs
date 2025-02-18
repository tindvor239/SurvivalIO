using RPG.Character;
using UnityEngine;

namespace RPG.Item
{
    public interface IWeaponize
    {
        public void Use<T>(T t, Transform spanwTransform) where T : MonoBehaviour, ICharacteristic;
    }
}