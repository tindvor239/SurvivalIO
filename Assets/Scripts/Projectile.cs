using RPG.Character;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string ignoreTag;
    public float damage;

    [SerializeField]
    private Rigidbody _rigidBod;
    [SerializeField]
    private float _speed;

    private void Start()
    {
        _rigidBod.AddForce(transform.forward.normalized * _speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (ignoreTag == other.gameObject.tag)
        {
            return;
        }

        MonoBehaviour[] components = other.transform.root.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour component in components)
        {
            if (component is ICharacteristic)
            {
                ICharacteristic characteristic = component as ICharacteristic;
                characteristic.TakeDamage(damage);
                if (component is IDropable)
                {
                    IDropable dropable = component as IDropable;
                    dropable.Drop();
                }
                return;
            }
        }

        Destroy(gameObject);
    }
}
