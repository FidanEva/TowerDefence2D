using UnityEngine;

public class TowerBaseMono : MonoBehaviour
{
    protected float _damage;
    protected float _bulletPerSecond;
    protected float _upgradeValue;
    public float Damage { get { return _damage; } }
    public float BulletPerSecond { get { return _bulletPerSecond; } }
    public float UpgradeValue { get { return _upgradeValue; } }
}
