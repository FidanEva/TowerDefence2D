using UnityEngine;

public class CastleController : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _gold;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyBaseMono>())
        {
            Debug.Log("tiggered");
        }
    }
}
