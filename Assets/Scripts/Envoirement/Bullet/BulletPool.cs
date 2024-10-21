using UnityEngine;

public class BuletPool : ObjectPool<Bullet>
{
    [SerializeField] private float _xOffset = 2;

    public SpawnerableObject GetBullet(Vector3 start, float _xDirectionShoot)
    {
        if (_pool.Count == 0)
        {
            Vector3 _targetVector3 = new Vector3(_xOffset, 0);
            SpawnerableObject obj = Instantiate(_prefab, start + _targetVector3, transform.rotation);
            obj.Returned += PutObject;
            obj.transform.parent = _container;

            return obj;
        }

        return _pool.Dequeue();
    }
}
