using UnityEngine;

public class BuletPool : ObjectPool<Bullet>
{
    [SerializeField] private float _xOffset = 2;
    [SerializeField] private float _initialValuePool = 5;

    public SpawnerableObject GetObject(Vector3 start, Quaternion rotation)
    {
        SpawnerableObject item;

        if (Pool.Count < _initialValuePool)
        {
            item = Init(start, rotation);

            return item;
        }

        item = Init(Pool.Dequeue(), start, rotation);

        return item;
    }

    private SpawnerableObject Init(Vector3 start, Quaternion rotation)
    {
        Vector3 _targetVector3 = new Vector3(_xOffset, 0);
        SpawnerableObject item = Instantiate(Prefab, start + _targetVector3, rotation);
        Activate(item);
        item.transform.parent = Container;

        return item;
    }

    private SpawnerableObject Init(SpawnerableObject item, Vector3 start, Quaternion rotation)
    {
        Vector3 _targetVector3 = new Vector3(_xOffset, 0);
        Activate(item);
        item.transform.position = start + _targetVector3;
        item.transform.rotation = rotation;

        return item;
    }
}