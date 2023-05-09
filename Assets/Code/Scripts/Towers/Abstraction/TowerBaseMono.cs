using UnityEngine;

public class TowerBaseMono : MonoBehaviour
{
    //public TowerBase towerData;

    [SerializeField] protected float _damage;
    [SerializeField] protected float _bulletPerSecond;
    [SerializeField] protected float _upgradeValue;
    public float Damage { get { return _damage; } }
    public float BulletPerSecond { get { return _bulletPerSecond; } }
    public float UpgradeValue { get { return _upgradeValue; } }
}
