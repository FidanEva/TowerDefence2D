using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _gold;

    [SerializeField] private GameObject _playModePanel;
    [SerializeField] private GameObject _losePanel;

    [SerializeField] private float _deadEnemies;
    [SerializeField] private TextMeshProUGUI _deadEnemiesTxt;

    private void OnEnable()
    {
        GameManager.Instance.OnRestartGame += RestartGame;
        GameManager.Instance.OnLooseGame += LooseGame;
        EventHolder.Instance.OnIncreaseGold += HandleGoldEvent;
        EventHolder.Instance.OnIncreaseGold += HandleHealthEvent;
    }
    public void RestartGame()
    {
        _losePanel.SetActive(false);
        _playModePanel.SetActive(true);
        _deadEnemies = 0;
    }

    private void LooseGame()
    {
        _deadEnemies = CastleController.Instance.DeadEnemies;
        _deadEnemiesTxt.text = "Killed enemies: " + _deadEnemies.ToString();
        _losePanel.SetActive(true);
        _playModePanel.SetActive(false);
    }

    private void HandleHealthEvent(float obj)
    {
        //Debug.Log(obj.ToString());
        _health.text = "Health: " + Mathf.RoundToInt(obj).ToString();
    }

    private void HandleGoldEvent(float obj)
    {
        //Debug.Log(obj.ToString());
        _gold.text = "Gold: " + Mathf.RoundToInt(obj).ToString();
    }
    public void UpgradeTower()
    {

    }

}
