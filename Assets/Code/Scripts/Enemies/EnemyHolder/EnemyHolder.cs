using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : SingletoneBase<EnemyHolder>
{
    public event Action OnAllEnemiesDie;

    [SerializeField] private List<GameObject> _enemyPool;
    [SerializeField] private int _enemyCount;

    public List<EnemyBase> enemies;
    private void Awake()
    {
        for (int i = 0; i < 25; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, enemies.Count);
            GameObject go = enemies[randomIndex].Activate();

            _enemyPool.Add(go);
            go.SetActive(false);
            go.transform.SetParent(transform);
        }
        _enemyCount = _enemyPool.Count;
    }
    public void CallEnemies(int count, Transform spawnPoint)
    {
        StartCoroutine(EnemyCooldown(count, spawnPoint));
    }
    IEnumerator EnemyCooldown(int count, Transform spawnPoint)
    {
        for (int i = 0; i < count; i++)
        {
            _enemyPool[_enemyPool.Count - 1].SetActive(true);
            _enemyPool[_enemyPool.Count - 1].transform.position = spawnPoint.position;
            _enemyPool.Remove(_enemyPool[_enemyPool.Count - 1]);
            yield return new WaitForSeconds(0.2f);
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