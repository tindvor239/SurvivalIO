using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private MapSAO mapSAO;
    [SerializeField]
    private Spawner spawnerPrefab;
    [SerializeField]
    private List<Spawner> spawners = new();

    private int waveIndex = 0;
    private float elapseTime = 0;

    private void Spawn()
    {
        elapseTime = mapSAO.Waves[waveIndex].WaveTime;

        foreach (Spawner spawn in spawners)
        {
            Destroy(spawn.gameObject);
        }
        spawners.Clear();

        for (int i = 0; i < mapSAO.Waves[waveIndex].WaveSpawners.Length; i++)
        {
            Spawner spawner = Instantiate(spawnerPrefab);
            spawner.waveSpawner = mapSAO.Waves[waveIndex].WaveSpawners[i];
            spawners.Add(spawner);
        }
    }

    private void Update()
    {
        elapseTime -= Time.deltaTime;

        if (elapseTime <= 0 && waveIndex < mapSAO.Waves.Length)
        {
            waveIndex++;
            Spawn();
        }
    }
}
