using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : SpawnerableObject
{
    [SerializeField] protected Transform Container;
    [SerializeField] protected SpawnerableObject Prefab;
    [SerializeField] protected Game Game;

    protected Queue<T> Pool;

    public IEnumerable<SpawnerableObject> PooledObjects => Pool;

    private void Awake()
    {
        Pool = new Queue<T>();
    }

    private void OnEnable()
    {
        Game.Play += Reset;
    }

    private void OnDisable()
    {
        Game.Play -= Reset;
    }

    public void Reset()
    {
        Pool.Clear();
        CloneContainer();
    }

    public SpawnerableObject GetObject()
    {
        SpawnerableObject item;

        if (Pool.Count < 3)
        {
            item = Init();
            Activate(item);

            return item;
        }

        item = Pool.Dequeue();
        Activate(item);

        return item;
    }

    protected void PutObject(SpawnerableObject item)
    {
        item.Returned -= PutObject;
        item.gameObject.SetActive(false);
        Pool.Enqueue(item as T);
    }

    protected void Activate(SpawnerableObject item)
    {
        item.Returned += PutObject;
        item.gameObject.SetActive(true);
    }

    protected void CloneContainer()
    {
        for (int i = 0; i < Container.childCount; i++)
        {
            var putableItem = Container.GetChild(i).gameObject;

            if (putableItem.TryGetComponent(out SpawnerableObject item))
                PutObject(item);
        }
    }

    private SpawnerableObject Init()
    {
        SpawnerableObject item = Instantiate(Prefab);
        item.transform.parent = Container;

        return item;
    }
}
