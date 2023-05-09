using System;

public class GameManager : SingletoneBase<GameManager>
{
    public event Action OnLooseGame;
    public event Action OnRestartGame;
    public void LooseGame()
    {
        OnLooseGame?.Invoke();
    }
    public void RestartGame()
    {
        OnRestartGame?.Invoke();
    }
}
