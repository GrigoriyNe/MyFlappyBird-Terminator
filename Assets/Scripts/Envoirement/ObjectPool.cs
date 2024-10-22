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
        SpawnerableObject obj;

        if (_pool.Count == 0)
        {
            obj = Init();

            return obj;
        }

        obj = Init(_pool.Dequeue());

        return obj;
    }

    protected void PutObject(SpawnerableObject obj)
    {
        _pool.Enqueue(obj as T);
        obj.Returned -= PutObject;
        obj.gameObject.SetActive(false);
    }

    protected SpawnerableObject Init(SpawnerableObject obj)
    {
        obj.Returned += PutObject;

        return obj;
    }

    private SpawnerableObject Init()
    {
        SpawnerableObject obj = Instantiate(_prefab);
        obj.transform.parent = _container;
        obj.Returned += PutObject;
        

        return obj;
    }

    private void CleanContainer()
    {
        while (_container.childCount > 0)
        {
            DestroyImmediate(_container.GetChild(0).gameObject);
        }
    }
}