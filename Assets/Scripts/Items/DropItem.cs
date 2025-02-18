using UnityEngine;

public class DropItem : MonoBehaviour
{
    [HideInInspector]
    public DropItemSAO itemSAO;

    protected Transform player;
    protected IPickupable pickupable;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IPickupable pickupable = Get<IPickupable>(other.gameObject);
            if (pickupable != null)
            {
                this.pickupable = pickupable;
                player = other.transform;
            }
        }
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.transform == player)
            pickupable.PickUp(itemSAO, OnPickupCallBack);
    }

    protected T Get<T>(GameObject gameObject) where T : class
    {
        foreach (Component component in gameObject.GetComponents<Component>())
        {
            if (component is T t)
            {
                player = component.transform;
                return t;
            }
        }
        return null;
    }

    protected virtual void OnPickupCallBack()
    {

    }
}