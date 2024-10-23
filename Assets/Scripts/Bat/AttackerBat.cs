using System.Collections;
using UnityEngine;

public class AttackerBat : Attacker
{
    [SerializeField] private InputReader _input;
    [SerializeField] private float _delayShootValue = 1f;

    private Coroutine _coroutine;
    private WaitForSecondsRealtime _delayAttack;

    private void OnEnable()
    {
        _input.IsAtack += Shoot;
    }

    private void OnDisable()
    {
        _input.IsAtack -= Shoot;
    }

    private void Start()
    {
        _delayAttack = new WaitForSecondsRealtime(_delayShootValue);
    }

    private void Shoot()
    {
        if (_coroutine == null)
        {
            Attack();
            _coroutine = StartCoroutine(Cooldowning());
        }
    }

    private IEnumerator Cooldowning()
    {
        yield return _delayAttack;
        _coroutine = null;
    }
}
