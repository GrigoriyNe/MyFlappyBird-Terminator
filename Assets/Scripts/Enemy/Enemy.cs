using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : SpawnerableObject, IInteractable
{
    [SerializeField] private int _shootDealayValue = 1;
    [SerializeField] private AttackerEnemy _attacker;
    [SerializeField] private SpriteObjectStorage _enemyStorage;
    
    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_shootDealayValue);
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _enemyStorage.GetSprite();

        if (_coroutine == null)
            _coroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            yield return _wait;

            _attacker.Attack();
        }
    }
}
