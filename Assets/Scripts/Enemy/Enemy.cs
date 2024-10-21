using System.Collections;
using UnityEngine;

public class Enemy : SpawnerableObject, IInteractable
{
    [SerializeField] private int _shootDealayValue = 1;
    [SerializeField] private AttackerEnemy _attacker;

    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_shootDealayValue);

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
