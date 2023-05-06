using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    private float _damage;
    private float _health;
    private float _gold;
    [SerializeField] EnemyBase _enemyData;
    public void Initialize(float health, float damage, float gold)
    {
        _health = health;
        _damage = damage;
        _gold = gold;
    }

    public void UpgradeProperties()
    {
        _damage += _damage * 0.1f;
        _health += _health * 0.1f;
        _gold += _gold * 0.1f;
    }
}
