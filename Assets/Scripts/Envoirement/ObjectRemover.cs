using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _poolEnemy;
    [SerializeField] private ScorePool _poolScore;
    [SerializeField] private BuletPool _poolBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out SpawnerableObject obj))
        {
            obj.Return();
        }
    }
}
