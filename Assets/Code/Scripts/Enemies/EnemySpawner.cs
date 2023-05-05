using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _nextSpawnWave = 1;

    [SerializeField] private float _timeSinceLastSpawn = 0.5f;
    [SerializeField] private float _enemyPerSecond;

    [SerializeField] private bool _isCoolDown = false;
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
        int enemyCount = UnityEngine.Random.Range(_nextSpawnWave, _nextSpawnWave + 10);
        EnemyHolder.Instance.CallEnemies(enemyCount, _spawnPoint);

        _nextSpawnWave++;
        if (!_isCoolDown)
        {
            StartCoroutine(EnemyCooldown());
            Debug.Log("iscooldown");
        }

    }
    IEnumerator EnemyCooldown()
    {
        _isCoolDown = true;
        yield return new WaitForSeconds(0.5f);
        _isCoolDown = false;
    }
}
