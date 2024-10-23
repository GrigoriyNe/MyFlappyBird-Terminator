using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : SpawnerableObject
{
    [SerializeField] protected Transform _container;
    [SerializeField] protected SpawnerableObject _prefab;
    [SerializeField] protected Game _game;
    
    protected Queue<T> _pool;

    public IEnumerable<SpawnerableObject> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    private void OnEnable()
    {
        _game.Play += Reset;
    }

    private void OnDisable()
    {
        _game.Play -= Reset;
    }

    public void Reset()
    {
        _pool.Clear();
        CleanContainer();
    }

    public SpawnerableObject GetObject()
    {
        SpawnerableObject item;

        if (_pool.Count == 0)
        {
            item = Init();

            return item;
        }

        item = Init(_pool.Dequeue());

        return item;
    }

    protected void PutObject(SpawnerableObject item)
    {
        _pool.Enqueue(item as T);
        item.Returned -= PutObject;
        item.gameObject.SetActive(false);
    }

    protected SpawnerableObject Init(SpawnerableObject item)
    {
        item.Returned += PutObject;

        return item;
    }

    private SpawnerableObject Init()
    {
        SpawnerableObject item = Instantiate(_prefab);
        item.transform.parent = _container;
        item.Returned += PutObject;
        
        return item;
    }

    private void CleanContainer()
    {
        while (_container.childCount > 0)
        {
            DestroyImmediate(_container.GetChild(0).gameObject);
        }
    }
}