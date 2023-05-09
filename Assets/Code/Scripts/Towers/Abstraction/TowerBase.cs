using UnityEngine;

public abstract class TowerBase : ScriptableObject
{
    public GameObject towerPrefab;

    public float damage;
    public float bulletPerSecond;
    public float upgradeValue;

    public abstract GameObject Activate();

    //public abstract void Restart();
}
