using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnMouseDown()
    {
        EnemyHolder.Instance.DestroyEnemy(gameObject);
    }
}
