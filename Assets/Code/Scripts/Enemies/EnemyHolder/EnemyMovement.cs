using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _movementSpeed;
    private Transform _target;
    private int _pathIndex;

    void Start()
    {
        _pathIndex = 0;
        _transform = GetComponent<Transform>();
        _target = LevelManager.Instance._cornerPoints[_pathIndex];
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


        //_transform.LookAt(_target);

        Vector3 direction = (_target.position - _transform.position).normalized;
        _transform.position += direction * _movementSpeed * Time.deltaTime;
        //_transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
    public void RestartRoad()
    {
        _pathIndex = 0;
        _target = LevelManager.Instance._cornerPoints[_pathIndex];
    }

}
