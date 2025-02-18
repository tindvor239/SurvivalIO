using UnityEngine;

namespace RPG.Item
{
    public interface IDropable
    {
        public float Percent { get; }

        public void Drop(Vector3 position);
    }
}