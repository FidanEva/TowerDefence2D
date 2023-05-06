using UnityEngine;

public abstract class EnemyBase : ScriptableObject
{
    public GameObject enemyPrefab;

    public float health;
    public float damage;
    public float gold;

    public abstract GameObject Activate();
}
