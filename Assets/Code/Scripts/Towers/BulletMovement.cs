using UnityEngine;
using UnityEngine.UIElements;

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

        transform.position += direction.normalized * (_speed * Time.deltaTime);

    }
    public void SetTarget(Transform newTarget)
    {
        _targetPos = newTarget.position;
        direction = (_targetPos - transform.position).normalized;
    }
}
