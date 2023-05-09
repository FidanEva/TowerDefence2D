using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    private float _defaultMoveSpeed;
    private Transform _target;
    private int _pathIndex;

    void Start()
    {
        _transform = GetComponent<Transform>();
        RestartRoad();
        _defaultMoveSpeed = _movementSpeed;
    }


    void Update()
    {
        if (Vector2.Distance(_target.position, _transform.position) <= 0.1f)
        {
            _pathIndex++;

            if (_pathIndex == LevelManager.Instance._cornerPoints.Length)
            {
                RestartRoad();
                EventHolder.Instance.InvokeOnEnemyFinish(GetComponent<EnemyBaseMono>());
                EnemyHolder.Instance.DestroyEnemy(gameObject);
                return;
            }
            else
            {
                _target = LevelManager.Instance._cornerPoints[_pathIndex];
            }
        }

        Vector3 direction = (_target.position - _transform.position).normalized;
        _transform.position += direction * _movementSpeed * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion toRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
    }
    public void RestartRoad()
    {
        _pathIndex = 0;
        _target = LevelManager.Instance._cornerPoints[_pathIndex];
    }
}
