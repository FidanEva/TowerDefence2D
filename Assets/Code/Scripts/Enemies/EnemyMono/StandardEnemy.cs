public class StandardEnemy : EnemyBaseMono, IDestructable
{
    private float _health;
    private float _gold;
    private float _damage;
    public float Gold { get { return _gold; } }
    public float Damage { get { return _damage; } }

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

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            EventHolder.Instance.InvokeEnemyDestroy(this);
            EnemyHolder.Instance.DestroyEnemy(gameObject);
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.GetComponent<BulletMovement>() != null)
        {
            if (collision.GetComponent<BulletMovement>().tower.TryGetComponent(out BasicTower tower))
            {
                TakeDamage(tower.Damage);
                BulletHolder.Instance.DestroyBullet(collision.gameObject);
            }
        }
    }
}
