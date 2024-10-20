using System.Collections;
using UnityEngine;

public class Bullet : SpawnerableObject, IInteractable
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _lifeTime = 2;

    private Coroutine _coroutine = null;
    private float _timer = 0;

    public void MakeShoot(float direction)
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Life(direction));
    }

    private IEnumerator Life(float direction)
    {

        while (_timer < _lifeTime)
        {

            _timer += Time.deltaTime;
            transform.Translate(transform.right * (direction * (Time.deltaTime * _speed)), Space.World);
            yield return null;
        }

        Destroy(gameObject);

       //  _pool.PutObject(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
