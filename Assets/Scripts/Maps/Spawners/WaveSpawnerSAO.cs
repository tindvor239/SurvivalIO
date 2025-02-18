using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Spawner", menuName = "Maps/WaveSpawnerSAO")]
public class WaveSpawnerSAO : ScriptableObject
{
    [SerializeField]
    private string id;
    [SerializeField]
    private float spawnDelay;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int spawnAmount;

    public string ID => id;
    public int SpawnAmount => spawnAmount;
    public float SpawnDelay => spawnDelay;
    public GameObject Enemy => enemy;
}