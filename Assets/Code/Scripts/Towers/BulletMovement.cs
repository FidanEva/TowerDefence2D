using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public TowerBaseMono tower;
    private Vector3 _targetPos;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    Vector3 direction;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_targetPos == null)
        {
            BulletHolder.Instance.DestroyBullet(gameObject);
            return;
        }

        //_rb.velocity = direction * _speed * Time.deltaTime;
        //transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);

        //transform.position += direction * _speed * Time.deltaTime;

    }
    public void SetTarget(Transform newTarget)
    {
        _targetPos = newTarget.position;
        direction = (_targetPos - transform.position).normalized;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out EnemyBaseMono enemy))
    //    {
    //        switch (enemy, tower)
    //        {
    //            case (StandardEnemy standard, BasicTower tower):
    //                Debug.Log("tower damage: " + tower.Damage);
    //                standard.TakeDamage(tower.Damage);
    //                break;
    //        }            
    //                BulletHolder.Instance.DestroyBullet(collision.gameObject);
    //    }
    //}
}
