using System;

public class EventHolder : SingletoneBase<EventHolder>
{
    public Action<EnemyBaseMono> OnEnemyFinish;
    public Action<EnemyBaseMono> OnEnemyDestroy;
    public Action<float> OnIncreaseGold;
    public Action<float> OnDecrreaseHealth;
    public void InvokeDecreaseHealth(float amount)
    {
        OnDecrreaseHealth?.Invoke(amount);
    }
    public void InvokeIncreaseGold(float amount)
    {
        OnIncreaseGold?.Invoke(amount);
    }
    public void InvokeEnemyDestroy(EnemyBaseMono enemy)
    {
        OnEnemyDestroy?.Invoke(enemy);
    }
    public void InvokeOnEnemyFinish(EnemyBaseMono enemy)
    {
        OnEnemyFinish?.Invoke(enemy);
    }
}
