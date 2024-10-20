using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : SpawnerableObject
{
    [SerializeField] protected Transform _container;
    [SerializeField] protected SpawnerableObject _prefab;

    protected Queue<SpawnerableObject> _pool;

    public int Counter => _pool.Count;
    public IEnumerable<SpawnerableObject> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<SpawnerableObject>();
    }

    public void Reset()
    {
        _pool.Clear();
    }

    public virtual SpawnerableObject GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_prefab);
            obj.transform.parent = _container;

            return obj;
        }

        return _pool.Dequeue();
    }

    public virtual void PutObject(SpawnerableObject obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
}