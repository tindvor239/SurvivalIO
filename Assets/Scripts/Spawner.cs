using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float _spawnRadius;
    [SerializeField]
    private float _excludeRadius;
    [SerializeField]
    private float _spawnElapse;
    [SerializeField]
    private int _spawnAmount;
    [SerializeField]
    private GameObject _spawnObject;

    private void Update()
    {
        _spawnElapse -= Time.deltaTime;
        if (_spawnElapse <= 0)
        {
            Spawn();
            _spawnElapse = 4f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _excludeRadius);
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            GameObject spawnObject = Instantiate(_spawnObject);
            spawnObject.transform.position = GetValidSpawnPosition();
        }
    }

    /// <summary>
    /// Tìm một vị trí hợp lệ bên ngoài vòng tròn nhỏ nhưng bên trong vòng tròn lớn.
    /// </summary>
    /// <returns>Vị trí Vector2 hợp lệ</returns>
    private Vector3 GetValidSpawnPosition()
    {
        Vector3 randomRadius = Random.insideUnitSphere * _spawnRadius;
        float x = Mathf.Clamp(randomRadius.x, _excludeRadius, _spawnRadius);
        if (randomRadius.x < 0)
        {
            x = Mathf.Clamp(randomRadius.x, -_excludeRadius, -_spawnRadius);
        }

        float y = Mathf.Clamp(randomRadius.y, _excludeRadius, _spawnRadius);
        if (randomRadius.y < 0)
        {
            y = Mathf.Clamp(randomRadius.y, -_excludeRadius, -_spawnRadius);
        }
        
        float z = Mathf.Clamp(randomRadius.z, _excludeRadius, _spawnRadius);
        if (randomRadius.z < 0)
        {
            z = Mathf.Clamp(randomRadius.z, -_excludeRadius, -_spawnRadius);
        }
        return new Vector3(x, y, z);
    }
}
