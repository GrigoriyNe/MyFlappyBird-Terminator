using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Jump = KeyCode.Space;
    private const int ValueOfLeftClickMouse = 0;

    public event Action IsFlyes;
    public event Action IsAtack;

    private void Update()
    {
        TryFly();
        TryAtack();
    }

    private void TryFly()
    {
        if (Input.GetKey(Jump))
            IsFlyes?.Invoke();
    }

    private void TryAtack()
    {

        if (Input.GetMouseButton(ValueOfLeftClickMouse))
            IsAtack?.Invoke();
    }
}
