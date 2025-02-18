using System;

public interface IPickupable
{
    public void PickUp(DropItemSAO itemSAO, Action onPickupCallBack);
}