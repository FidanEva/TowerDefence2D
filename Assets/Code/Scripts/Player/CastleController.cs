using System;
using UnityEngine;

public class CastleController : SingletoneBase<CastleController>
{
    [SerializeField] private float _health;
    [SerializeField] private float _gold;
    [SerializeField] private float _defaultHealth;
    [SerializeField] private float _defaultGold;

    [SerializeField] private float _deadEnemies;
    public float DeadEnemies { get { return _deadEnemies; } }
    public float Gold { get { return _gold; } }
    private void OnEnable()
    {
        GameManager.Instance.OnRestartGame += RestartGame;
        EventHolder.Instance.OnEnemyFinish += HandleEnemyFinishEvent;
        EventHolder.Instance.OnEnemyDestroy += HandleEnemyDestroyEvent;
    }

    private void RestartGame()
    {
        _health = _defaultHealth;
        _gold = _defaultGold;

        _deadEnemies = 0;

        EventHolder.Instance.InvokeIncreaseGold(_gold);
        EventHolder.Instance.InvokeDecreaseHealth(_health);
    }

    private void Awake()
    {
        //Debug.Log(_gold);
        //Debug.Log(_health);
        EventHolder.Instance.InvokeIncreaseGold(_gold);
        EventHolder.Instance.InvokeDecreaseHealth(_health);
    }
    private void Start()
    {
        _defaultHealth = _health;
        _defaultGold = _gold;
    }
    private void HandleEnemyDestroyEvent(EnemyBaseMono obj)
    {
        switch (obj)
        {
            case StandardEnemy enemy:
                _gold += enemy.Gold;
                _deadEnemies++;
                EventHolder.Instance.InvokeIncreaseGold(_gold);
                break;
        }
    }

    private void HandleEnemyFinishEvent(EnemyBaseMono obj)
    {
        if (obj.TryGetComponent(out StandardEnemy enemy))
        {
            _health -= enemy.Damage;
            if (_health <= 0)
            {
                _health = 0;
                GameManager.Instance.LooseGame();
            }
        }
        EventHolder.Instance.InvokeDecreaseHealth(_health);
    }
}
