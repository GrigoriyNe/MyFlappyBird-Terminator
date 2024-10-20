using Unity.VisualScripting;
using UnityEngine;


public class BuletPool : ObjectPool<Bullet>
{
    public SpawnerableObject GetObject(Vector3 _targetVector3)
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_prefab, transform.position + _targetVector3, transform.rotation);
            obj.transform.parent = _container;

            return obj;
        }

        return _pool.Dequeue();
    }

    public override void PutObject(SpawnerableObject obj)
    {
        if (_pool.Count < 10)
            _pool.Enqueue(obj);
        else
            Destroy(_pool.Dequeue());

        obj.gameObject.SetActive(false);
    }
}
