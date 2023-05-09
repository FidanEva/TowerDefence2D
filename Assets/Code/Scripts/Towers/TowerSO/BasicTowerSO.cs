using UnityEngine;

[CreateAssetMenu(fileName = "Basic", menuName = "Towers/Basic")]
public class BasicTowerSO : TowerBase
{
    public override GameObject Activate()
    {
        BasicTower tower = towerPrefab.GetComponent<BasicTower>();
        tower.Initialize(damage, bulletPerSecond, upgradeValue);
        Debug.Log(tower.ToString());
        return towerPrefab;
    }
}
