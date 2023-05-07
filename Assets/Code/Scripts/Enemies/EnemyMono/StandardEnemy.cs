using UnityEngine;

public class StandardEnemy : EnemyBaseMono
{
    private float _health;
    private float _gold;
    private float _damage;
    public float Damage
    {
        get
        {
            return _damage;
        }
    }
    public void Initialize(float health, float damage, float gold)
    {
        _health = health;
        _damage = damage;
        _gold = gold;
        Debug.Log(_damage);
    }

    public void UpgradeProperties()
    {
        _damage += _damage * 0.1f;
        _health += _health * 0.1f;
        _gold += _gold * 0.1f;
        Debug.Log(_damage);
    }
}
