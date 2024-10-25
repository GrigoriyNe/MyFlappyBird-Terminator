using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] private BulletPool _bullets;
    [SerializeField] private float _xDirectionShoot;
    [SerializeField] private float _xOffset = 2;

    public void Attack()
    {
        Vector3 vectorOffset = new Vector3(_xOffset, 0);
        SpawnerableObject newBullet = _bullets.GetObject(transform.position + vectorOffset, transform.rotation);

        if (newBullet.TryGetComponent(out Bullet bullet))
            bullet.SetDirection(_xDirectionShoot);
    }
}
