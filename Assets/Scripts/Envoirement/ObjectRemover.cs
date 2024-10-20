using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _poolEnemy;
    [SerializeField] private ScorePool _poolScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _poolEnemy.PutObject(enemy);
        }
        if (other.TryGetComponent(out ScoreZone score))
        {
            _poolScore.PutObject(score);
        }
    }
}
