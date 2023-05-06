using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _nextSpawnWave = 1;
    private void OnEnable()
    {
        EnemyHolder.Instance.OnAllEnemiesDie += CallNewWave;
    }
    void Start()
    {
        CallNewWave();
    }

    private void CallNewWave()
    {
        int enemyCount = Random.Range(_nextSpawnWave, _nextSpawnWave + 10);
        EnemyHolder.Instance.CallEnemies(enemyCount, _spawnPoint);
        Debug.Log(enemyCount);
        _nextSpawnWave++;
    }
}

