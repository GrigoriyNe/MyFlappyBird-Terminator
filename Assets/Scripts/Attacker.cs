using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] private BuletPool _pool;
    [SerializeField] private float _xDirectionShoot;

    public void Attack()
    {
        float _xOffset = 3;

        Vector3 _targetVector3 = new Vector3(_xOffset, 0);
        SpawnerableObject newBullet =_pool.GetBullet(transform.position, _xDirectionShoot);
        newBullet.TryGetComponent(out Bullet bullet);
        bullet.MakeShoot(_xDirectionShoot);
    }
}