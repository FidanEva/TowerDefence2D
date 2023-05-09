using TMPro;
using UnityEngine;

public class BasicTower : TowerBaseMono
{

    private float _defaultDamage;
    private float _defaultBulletPerSecond;
    private float _defaultUpgradeValue;

    public TextMeshPro upgradeValueText;

    public void Initialize(float damage, float bulletPerSecond, float upgradeValue)
    {
        _damage = damage;
        _bulletPerSecond = bulletPerSecond;
        _upgradeValue = upgradeValue;

        _defaultDamage = _damage;
        _defaultBulletPerSecond = _bulletPerSecond;
        _defaultUpgradeValue = _upgradeValue;

        upgradeValueText = transform.GetChild(2).GetComponent<TextMeshPro>();
        upgradeValueText.text = Mathf.RoundToInt(_upgradeValue).ToString();
    }
    public void Restart()
    {
        _damage = _defaultDamage;
        _bulletPerSecond = _defaultBulletPerSecond;
        _upgradeValue = _defaultUpgradeValue;

        upgradeValueText.text = Mathf.RoundToInt(_upgradeValue).ToString();
        upgradeValueText = transform.GetChild(2).GetComponent<TextMeshPro>();
    }
    public void OnMouseDown()
    {
        if (CastleController.Instance.Gold >= _upgradeValue)
        {
            GameManager.Instance.UpgradeTower(this);
            _damage += _damage * 0.3f;
            _bulletPerSecond += _bulletPerSecond * 0.3f;
            _upgradeValue += _upgradeValue * 0.3f;

            upgradeValueText = transform.GetChild(2).GetComponent<TextMeshPro>();
            upgradeValueText.text = Mathf.RoundToInt(_upgradeValue).ToString();
        }
    }
}
