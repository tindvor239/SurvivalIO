using RPG.Character;
using UnityEngine;

public abstract class WeaponFunctionSAO : ScriptableObject
{
    public abstract void OnUsed<T>(T owner, Transform spawnTransform) where T : MonoBehaviour, ICharacteristic;
}