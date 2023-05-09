using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : SingletoneBase<EnemyHolder>
{
    [SerializeField] private List<GameObject> _enemyPool;
    [SerializeField] private int _enemyCount;

    public List<EnemyBase> enemies;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _spawnWave = 1;

    private bool _dead = false;
    private void OnEnable()
    {
        GameManager.Instance.OnLooseGame += StopSpawning;
        GameManager.Instance.OnRestartGame += StartSpawning;
    }

    private void StartSpawning()
    {
        _dead = false;
        _spawnWave = 1;
        int enemyCount = Random.Range(_spawnWave, _spawnWave + 10);
        CallEnemies(enemyCount, _spawnPoint);
    }

    private void StopSpawning()
    {
        _dead = true;
        foreach (var enemy in FindObjectsOfType<EnemyMovement>())
        {
            DestroyEnemy(enemy.gameObject);
        }
    }

    private void Awake()
    {
        for (int i = 0; i < 25; i++)
        {
            int randomIndex = Random.Range(0, enemies.Count);
            GameObject go = enemies[randomIndex].Activate();

            _enemyPool.Add(go);
            go.SetActive(false);
            go.transform.SetParent(transform);
        }
        _enemyCount = _enemyPool.Count;
    }
    private void Start()
    {
        int enemyCount = Random.Range(_spawnWave, _spawnWave + 10);
        Debug.Log(enemyCount);
        CallEnemies(enemyCount, _spawnPoint);
    }
    public void CallEnemies(int count, Transform spawnPoint)
    {
        if (_dead)
        {
            return;
        }
        StartCoroutine(EnemyCooldown(count, spawnPoint));
    }
    IEnumerator EnemyCooldown(int count, Transform spawnPoint)
    {
        if (_enemyPool.Count > count)
        {
            for (int i = 0; i < count; i++)
            {
                if (_spawnWave > 1)
                {
                    _enemyPool[_enemyPool.Count - 1].GetComponent<StandardEnemy>().UpgradeProperties();
                }
                _enemyPool[_enemyPool.Count - 1].GetComponent<EnemyMovement>().RestartRoad();
                _enemyPool[_enemyPool.Count - 1].SetActive(true);
                _enemyPool[_enemyPool.Count - 1].transform.position = spawnPoint.position;
                _enemyPool.Remove(_enemyPool[_enemyPool.Count - 1]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    public void DestroyEnemy(GameObject obj)
    {
        obj.SetActive(false);
        _enemyPool.Add(obj);

        if (_enemyPool.Count == _enemyCount)
        {
            _spawnWave++;
            int enemyCount = Random.Range(_spawnWave, _spawnWave + 10);
            Debug.Log(enemyCount);
            CallEnemies(enemyCount, _spawnPoint);
        }
    }
}
