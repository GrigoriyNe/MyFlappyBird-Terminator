using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : SpawnerableObject, IInteractable
{
    [SerializeField] private int _shootDealayValue = 2;
    [SerializeField] private Bullet _bullet;
    [SerializeField] float _positiveDirectionShoot;
    [SerializeField] private Attacker _attacker;

    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;
    private int _bulletValueTarget = 5;

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
