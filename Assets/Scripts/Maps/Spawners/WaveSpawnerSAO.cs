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
    [SerializeField]
    private SpawnType type = SpawnType.Minion;

    public string ID => id;
    public int SpawnAmount => spawnAmount;
    public float SpawnDelay => spawnDelay;
    public GameObject Enemy => enemy;
    public SpawnType Type => type;

    public enum SpawnType
    {
        Minion,
        Boss
    }
}