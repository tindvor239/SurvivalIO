using RPG.Item;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemSAO", menuName = "Item/DropItem")]
public class DropItemSAO : BaseItemSAO, IDropable
{
    [SerializeField]
    private float percent;
    [SerializeField]
    private DropItem dropPrefab;

    public float Percent => percent;

    public void Drop(Vector3 position)
    {
        float randomPercent = Random.Range(0, 100);
        if (randomPercent <= percent)
        {
            DropItem item = Instantiate(dropPrefab);
            item.itemSAO = this;
            item.transform.position = position;
        }
    }
}