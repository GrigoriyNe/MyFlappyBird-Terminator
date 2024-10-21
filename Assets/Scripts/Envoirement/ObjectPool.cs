using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : SpawnerableObject
{
    [SerializeField] protected Transform _container;
    [SerializeField] protected SpawnerableObject _prefab;

    protected Queue<T> _pool;

    public IEnumerable<SpawnerableObject> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public void Reset()
    {
        _pool.Clear();

        while (_container.childCount > 0)
        {
            DestroyImmediate(_container.GetChild(0).gameObject);
        }
    }

    public SpawnerableObject GetObject()
    {
        if (_pool.Count == 0)
        {
            SpawnerableObject obj = Instantiate(_prefab);
            obj.transform.parent = _container;
            obj.Returned += PutObject;

            return obj;
        }
        
        return _pool.Dequeue();
    }

    public void PutObject(SpawnerableObject obj)
    {
        _pool.Enqueue(obj as T);
        obj.Returned -= PutObject;
        obj.gameObject.SetActive(false);
    }
}