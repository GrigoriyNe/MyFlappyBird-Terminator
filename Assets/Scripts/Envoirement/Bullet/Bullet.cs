using System.Collections;
using UnityEngine;

public class Bullet : SpawnerableObject, IInteractable
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _lifeTime = 2;

    private float _direction;
    private float _timer = 0;
    private Coroutine _coroutine = null;

    private void Update()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Life(_direction));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Return();
            Return();
        }
    }

    private void OnDisable()
    {
        _timer = 0;
        _coroutine = null;
        gameObject.SetActive(false);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
    }

    private IEnumerator Life(float direction)
    {
        while (_timer < _lifeTime && enabled)
        {
            _timer += Time.deltaTime;
            transform.Translate(transform.right * (direction * (Time.deltaTime * _speed)), Space.World);
            yield return null;
        }

        Return();
    }
}
