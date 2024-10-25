using System.Collections;
using UnityEngine;

public abstract class ObjectGenerator<T> : MonoBehaviour where T : SpawnerableObject
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool<T> _pool;

    private void Start()
    {
        StartCoroutine(GenerateObject());
    }

    private IEnumerator GenerateObject()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector2 spawnPoint = new Vector2(transform.position.x, spawnPositionY);

        var item = _pool.GetObject();

        item.gameObject.SetActive(true);
        item.transform.position = spawnPoint;
    }
}