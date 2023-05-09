using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicTower : TowerBaseMono
{
    private float _damage;
    private float _bulletPerSecond;
    private float _upgradeValue;
    public TextMeshPro upgradeValueText;

    public float Damage { get { return _damage; } }
    public float BulletPerSecond { get { return _bulletPerSecond; } }
    public float UpgradeValue { get { return _upgradeValue; } }

    public void Initialize(float damage, float bulletPerSecond, float upgradeValue)
    {
        _damage = damage;
        _bulletPerSecond = bulletPerSecond;
        _upgradeValue = upgradeValue;

        upgradeValueText = transform.GetChild(2).GetComponent<TextMeshPro>();
        upgradeValueText.text = Mathf.RoundToInt(_upgradeValue).ToString();
    }
    public void UpgradeProperties()
    {
        if (CastleController.Instance.Gold >= _upgradeValue)
        {
            _damage += _damage * 0.3f;
            _bulletPerSecond += _bulletPerSecond * 0.3f;
            _upgradeValue += _upgradeValue * 0.3f;

            upgradeValueText = transform.GetChild(2).GetComponent<TextMeshPro>();
            upgradeValueText.text = Mathf.RoundToInt(_upgradeValue).ToString();
        }
    }
    private void OnMouseDown()
    {
        UpgradeProperties();
    }
}
