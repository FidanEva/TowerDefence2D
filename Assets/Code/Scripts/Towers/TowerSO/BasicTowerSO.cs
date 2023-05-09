using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic", menuName = "Towers/Basic")]
public class BasicTowerSO : TowerBase
{
    private List<GameObject> towers;
    public override GameObject Activate()
    {
        GameObject tower = Instantiate(towerPrefab);
        tower.GetComponent<BasicTower>().Initialize(damage, bulletPerSecond, upgradeValue);
        towers.Add(tower);
        return tower;
    }
}
