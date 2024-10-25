using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] private BuletPool _pool;
    [SerializeField] private float _xDirectionShoot;

    public void Attack()
    {
        SpawnerableObject newBullet = _pool.GetObject(transform.position, transform.rotation);

        if (newBullet.TryGetComponent(out Bullet bullet))
            bullet.SetDirection(_xDirectionShoot);
    }
}
