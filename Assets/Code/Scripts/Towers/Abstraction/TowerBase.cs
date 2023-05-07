using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float damage;
    public float bulletPerSecond;
    public float upgradeValue;

    public abstract void Fire();
}
