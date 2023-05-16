using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : SingletoneBase<EnemyHolder>
{
    [SerializeField] private List<GameObject> _enemyPool;
    [SerializeField] private int _enemyCount;
    //[SerializeField] private int _spawnedMaxEnemies;

    public List<EnemyBase> enemies;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _spawnWave = 1;

    private bool _dead = false;
    private void OnEnable()
    {
        GameManager.Instance.OnLooseGame += StopSpawning;
        GameManager.Instance.OnRestartGame += StartSpawning;
    }

    private void Awake()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            int randomIndex = Random.Range(0, enemies.Count);
            GameObject go = enemies[randomIndex].Activate();

            _enemyPool.Add(go);
            go.SetActive(false);
            go.transform.SetParent(transform);
        }
        //_enemyCount = _enemyPool.Count;
    }
    private void Start()
    {
        CallEnemies(_spawnPoint);
    }

    private void StartSpawning()
    {
        _dead = false;
        _spawnWave = 1;
        CallEnemies(_spawnPoint);
    }

    private void StopSpawning()
    {
        _dead = true;
        foreach (var enemy in FindObjectsOfType<EnemyMovement>())
        {
            DestroyEnemy(enemy.gameObject);
        }
    }
    public void CallEnemies(Transform spawnPoint)
    {
        if (_dead)
        {
            return;
        }
        StartCoroutine(EnemyCooldown(spawnPoint));
    }
    IEnumerator EnemyCooldown(Transform spawnPoint)
    {
        int count = Random.Range(_spawnWave, _spawnWave + 10);
        if (_enemyPool.Count < count)
        {
            count = _enemyPool.Count;
        }

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
            yield return new WaitForSeconds(0.35f);
        }
    }

    public void DestroyEnemy(GameObject obj)
    {
        obj.SetActive(false);
        _enemyPool.Add(obj);

        if (_enemyPool.Count == _enemyCount)
        {
            _spawnWave++;
            CallEnemies(_spawnPoint);
        }
    }
}
