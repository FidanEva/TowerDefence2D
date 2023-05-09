using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _towerList;
    [SerializeField] private List<Transform> _towerPoints;
    [SerializeField] private List<TowerBase> _towerBaseList;
    private void OnEnable()
    {
        GameManager.Instance.OnRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        foreach (var tower in _towerList)
        {
            tower.GetComponent<BasicTower>().Restart();
        }
    }

    private void Awake()
    {
        foreach (var tower in _towerPoints)
        {
            int randomIndex = Random.Range(0, _towerBaseList.Count);
            GameObject go = _towerBaseList[randomIndex].Activate();
            go.transform.position = tower.transform.position;
            go.transform.parent = tower.transform;
            _towerList.Add(go);  
        }
    }
}
