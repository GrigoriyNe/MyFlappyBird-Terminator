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
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var obj = _pool.GetObject();

        obj.gameObject.SetActive(true);
        obj.transform.position = spawnPoint;
    }
}