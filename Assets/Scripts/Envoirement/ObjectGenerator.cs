using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ObjectGenerator<T> : MonoBehaviour where T : SpawnerableObject
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool<T> _prefab;


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

        var @object = _prefab.GetObject();

        @object.gameObject.SetActive(true);
        @object.transform.position = spawnPoint;
    }
}