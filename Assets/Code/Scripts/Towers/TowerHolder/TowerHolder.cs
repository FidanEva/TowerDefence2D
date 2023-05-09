using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _towerList;
    private void OnEnable()
    {
        GameManager.Instance.OnLooseGame += LooseGame;
        GameManager.Instance.OnRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        foreach (var tower in FindObjectsOfType<TowerBaseMono>())
        {
            tower.GetComponent<BasicTower>().Initialize(tower.GetComponent<TowerBaseMono>().towerData.damage, tower.GetComponent<TowerBaseMono>().towerData.bulletPerSecond, tower.GetComponent<TowerBaseMono>().towerData.upgradeValue);

            _towerList.Add(tower.gameObject);
        }
    }

    private void LooseGame()
    {
        Debug.Log("towers");
    }

    private void Awake()
    {
        foreach (var tower in FindObjectsOfType<TowerBaseMono>())
        {
            //tower.GetComponent<TowerBaseMono>().towerData.Activate();
            tower.GetComponent<BasicTower>().Initialize(tower.GetComponent<TowerBaseMono>().towerData.damage, tower.GetComponent<TowerBaseMono>().towerData.bulletPerSecond, tower.GetComponent<TowerBaseMono>().towerData.upgradeValue);

            _towerList.Add(tower.gameObject);  
            //Debug.Log("tower" + tower.GetComponent<TowerBaseMono>().towerData.damage);
            //Debug.Log("basic" + tower.GetComponent<BasicTower>().Damage);
        }
    }
}
