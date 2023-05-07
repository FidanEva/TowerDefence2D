using UnityEngine;

[CreateAssetMenu(fileName = "Standard", menuName = "Enemies/Standard")]
public class StandardEnemySO : EnemyBase
{
    public override GameObject Activate()
    {
        GameObject enemyGO = Instantiate(enemyPrefab);
        StandardEnemy standard = enemyGO.GetComponent<StandardEnemy>();
        standard.Initialize(health, damage, gold);
        return enemyGO;
    }
}
