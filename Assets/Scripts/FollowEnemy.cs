using RPG.Character;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class FollowEnemy : MonoBehaviour, ICharacteristic, IDropable, IDeathable
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private CharacterStatSAO _data;
    [SerializeField]
    private DropItemSAO _dropItem;
    [SerializeField]
    private Stats _currentStats;
    [Space]
    [SerializeField]
    private UnityEvent<IDeathable> onDeath = new();

    public Stats CurrentStats => _currentStats;
    public CharacterStatSAO Data => _data;

    public DropItemSAO DropItem => throw new System.NotImplementedException();

    public UnityEvent<IDeathable> OnDeath => onDeath;

    public void TakeDamage(float damageDeal)
    {
        _currentStats.health -= damageDeal;
        if (_currentStats.health <= 0)
        {
            Drop();
            Destroy(gameObject);
            this.PostEvent(EventID.OnEnemyDeath);
            onDeath?.Invoke(this);
        }
    }

    private void Awake()
    {
        _currentStats = _data.Stats;
        _target = FindFirstObjectByType<Player>().transform;
    }

    private void Update()
    {
        _navMeshAgent.speed = _currentStats.movementSpeed;
        _navMeshAgent.SetDestination(_target.position);
        _currentStats.attackRate = Mathf.Clamp(_currentStats.attackRate - Time.deltaTime, 0, _data.Stats.attackRate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_currentStats.attackRate <= 0)
        {
            _currentStats.attackRate = _data.Stats.attackRate;
            if (other.gameObject.transform == _target)
            {
                _target.GetComponent<Player>().TakeDamage(_currentStats.damage);
                _currentStats.attackRate = _data.Stats.attackRate;
            }
        }
    }

    public void Drop()
    {
        _dropItem.Drop(transform.position);
        Debug.Log("Dropped");
    }
}
