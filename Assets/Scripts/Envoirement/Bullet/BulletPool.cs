using UnityEngine;

public class BuletPool : ObjectPool<Bullet>
{
    [SerializeField] private float _xOffset = 2;
    [SerializeField] private float _initialValuePool = 10;

    public SpawnerableObject GetObject(Vector3 start)
    {
        SpawnerableObject obj;

        if (_pool.Count < _initialValuePool)
        {
            obj = Init(start);
           
            return obj;
        }

        obj = Init(_pool.Dequeue());

        return obj;
    }

    private SpawnerableObject Init(Vector3 start)
    {
        Vector3 _targetVector3 = new Vector3(_xOffset, 0);
        SpawnerableObject obj =  Instantiate(_prefab, start + _targetVector3, transform.rotation);
        obj.Returned += PutObject;
        obj.transform.parent = _container;

        return obj;
    }
}
