using UnityEngine;

public class BuletPool : ObjectPool<Bullet>
{
    [SerializeField] private float _xOffset = 2;
    [SerializeField] private float _initialValuePool = 5;

    public SpawnerableObject GetObject(Vector3 start)
    {
        SpawnerableObject item;

        if (_pool.Count < _initialValuePool)
        {
            item = Init(start);
           
            return item;
        }

        item = Init(_pool.Dequeue());

        return item;
    }

    private SpawnerableObject Init(Vector3 start)
    {
        Vector3 _targetVector3 = new Vector3(_xOffset, 0);
        SpawnerableObject item =  Instantiate(_prefab, start + _targetVector3, transform.rotation);
        item.Returned += PutObject;
        item.transform.parent = _container;

        return item;
    }
}
