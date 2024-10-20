using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _poolEnemy;
    [SerializeField] private BuletPool _poolBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _poolEnemy.PutObject(enemy);
        }
        if (other.TryGetComponent(out Bullet bullet))
        {
            _poolBullet.PutObject(bullet);
        }
    }
}
