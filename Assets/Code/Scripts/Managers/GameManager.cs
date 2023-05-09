using System;

public class GameManager : SingletoneBase<GameManager>
{
    public event Action OnLooseGame;
    public event Action OnRestartGame;

    public event Action<TowerBaseMono> OnUpgradeTower;
    public void LooseGame()
    {
        OnLooseGame?.Invoke();
    }
    public void RestartGame()
    {
        OnRestartGame?.Invoke();
    }
    public void UpgradeTower(TowerBaseMono tower)
    {
        OnUpgradeTower?.Invoke(tower);
    }
    
}
