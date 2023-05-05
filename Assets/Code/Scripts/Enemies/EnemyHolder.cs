using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : SingletoneBase<EnemyHolder>
{
    public event Action OnAllEnemiesDie;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<GameObject> _enemyPool;
    [SerializeField] private int _enemyCount;

    private void Awake()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject go = Instantiate(_enemyPrefab);
            _enemyPool.Add(go);
            go.SetActive(false);
            go.transform.SetParent(transform);
        }
        _enemyCount = _enemyPool.Count;
    }
    public void CallEnemies(int count, Transform spawnPoint)
    {
        if (_enemyPool.Count >= count)
        {
            for (int i = 0; i < count; i++)
            {
                _enemyPool[_enemyPool.Count - 1].SetActive(true);
                _enemyPool[_enemyPool.Count - 1].transform.position = spawnPoint.position;
                _enemyPool.Remove(_enemyPool[_enemyPool.Count - 1]);
            }
        }
    }

    public void DestroyEnemy(GameObject obj)
    {
        obj.SetActive(false);
        _enemyPool.Add(obj);

        if (_enemyPool.Count == _enemyCount)
        {
            OnAllEnemiesDie?.Invoke();
        }
    }
}
