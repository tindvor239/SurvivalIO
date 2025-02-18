using System.Collections.Generic;

public interface IPrepared
{
    public Dictionary<string, IEquipable> ArmourMap { get; }
    public List<IEquipable> HandSlots { get; }

    public void EquipWeapons(int slotIndex, WeaponSAO weaponSAO);
    public void EquipArmour(int slotIndex);
}