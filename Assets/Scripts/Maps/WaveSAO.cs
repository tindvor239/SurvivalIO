using UnityEngine;

[CreateAssetMenu(fileName = "New Wave SAO", menuName = "Maps/WaveSAO")]
public class WaveSAO : ScriptableObject
{
    [SerializeField]
    private string id;
    [SerializeField]
    private WaveSpawnerSAO[] waveSpawners = new WaveSpawnerSAO[0];
    [SerializeField]
    private float waveTime;

    public string ID => id;
    public WaveSpawnerSAO[] WaveSpawners => waveSpawners;
    public float WaveTime => waveTime;
}