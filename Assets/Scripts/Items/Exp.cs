using RPG.Character;
using UnityEngine;

public class Exp : DropItem
{
    private const float SPEED = 10f;

    [SerializeField]
    private int amount;
    [SerializeField]
    private Trigger trigger;

    public int Amount => amount;

    private void Awake()
    {
        trigger.OnTriggerEnterCallBack.AddListener(OnTriggerEnterCallBack);
        trigger.OnTriggerExitCallBack.AddListener(OnTriggerExitCallBack);
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }
        Vector3 direction = player.position - transform.position;
        transform.position += direction.normalized * Time.deltaTime * SPEED;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            pickupable.PickUp(itemSAO, OnPickupCallBack);
            Destroy(gameObject);
        }
    }

    protected override void OnPickupCallBack()
    {
        if (this.player.TryGetComponent(out Player player))
        {
            player.exp += amount;
        }
    }

    private void OnTriggerEnterCallBack(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IPickupable pickupable = Get<IPickupable>(other.gameObject);
            if (pickupable != null)
            {
                this.pickupable = pickupable;
            }
        }
    }

    private void OnTriggerExitCallBack(Collider other)
    {
        if (other.transform == player)
        {
            player = null;
        }
    }
}