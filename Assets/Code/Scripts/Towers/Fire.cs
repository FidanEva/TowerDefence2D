using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _radius;

    [SerializeField] private float fireSpellStart;
    [SerializeField] private float fireSpellCooldown;

    [SerializeField] private float _currentDistance;
    [SerializeField] Collider2D _minCollider;
    void Update()
    {
        if (Time.time > fireSpellStart + 1 / fireSpellCooldown)
        {
            fireSpellStart = Time.time;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);
            if (colliders.Length == 0)
            {
                return;
            }

            float closestDistance = Mathf.Infinity;

            foreach (Collider2D collider in colliders)
            {
                _currentDistance = Vector2.Distance(collider.transform.position, transform.position);

                if (_currentDistance < closestDistance)
                {
                    closestDistance = _currentDistance;
                    _minCollider = collider;
                }
            }
            FireBullet();
        }
    }

    public void FireBullet()
    {
        GameObject go = BulletHolder.Instance.CallBullet();
        if (go != null)
        {
            go.transform.position = transform.position;
            go.GetComponent<BulletMovement>().SetTarget(_minCollider.transform);
            go.GetComponent<BulletMovement>().tower = GetComponent<TowerBaseMono>();
        }
    }
}
