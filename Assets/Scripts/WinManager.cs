using UnityEngine;

public class WinManager : MonoBehaviour
{
    private int spawned;
    private int killed;
    private bool isLastWave = false;

    private void Awake()
    {
        this.RegisterListener(EventID.OnEnemyDeath, OnEnemyDeath);
        this.RegisterListener(EventID.OnEnemySpawn, OnEnemySpawn);
        this.RegisterListener(EventID.OnPlayerDeath, OnPlayerDeath);
        this.RegisterListener(EventID.OnLastWaves, OnLastWaves);
    }

    private void OnDestroy()
    {
        this.RemoveListener(EventID.OnEnemyDeath, OnEnemyDeath);
        this.RemoveListener(EventID.OnEnemyDeath, OnEnemyDeath);
        this.RemoveListener(EventID.OnPlayerDeath, OnPlayerDeath);
        this.RemoveListener(EventID.OnLastWaves, OnLastWaves);
    }

    private void OnEnemyDeath(object param)
    {
        killed++;
        if (killed == spawned && isLastWave)
        {
            Debug.Log("You win!");
            this.PostEvent(EventID.OnWin, killed);
        }
    }

    private void OnPlayerDeath(object param)
    {
        this.PostEvent(EventID.OnGameOver, killed);
    }

    private void OnEnemySpawn(object param)
    {
        spawned++;
    }

    private void OnLastWaves(object param)
    {
        isLastWave = true;
    }
}
