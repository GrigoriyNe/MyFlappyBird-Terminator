using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
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
        SpawnerableObject item = Instantiate(Prefab, start, rotation);
        Activate(item);
        item.transform.parent = Container;

        return item;
    }

    private SpawnerableObject Init(SpawnerableObject item, Vector3 start, Quaternion rotation)
    {
        Activate(item);
        item.transform.position = start;
        item.transform.rotation = rotation;

        return item;
    }
}