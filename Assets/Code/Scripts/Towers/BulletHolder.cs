using System.Collections.Generic;
using UnityEngine;

public class BulletHolder : SingletoneBase<BulletHolder>
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<GameObject> _bullets;

    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject go = Instantiate(_bulletPrefab);
            go.SetActive(false);
            go.transform.SetParent(transform);
            _bullets.Add(go);
        }
    }

    public GameObject CallBullet()
    {
        if (_bullets.Count == 0)
        {
            return null;
        }
        GameObject go = _bullets[_bullets.Count - 1];
        go.SetActive(true);
        _bullets.Remove(go);
        return go;

    }
    public void DestroyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bullets.Add(bullet);
    }
}
