using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Jump = KeyCode.Space;
    private const int ValueOfLeftClickMouse = 0;

    public event Action<bool> IsFlyes;
    public event Action<bool> IsAtack;

    private void Update()
    {
        TryFly();
        TryAtack();
    }

    private void TryFly()
    {
        IsFlyes?.Invoke(false);

        if (Input.GetKey(Jump))
            IsFlyes?.Invoke(true);
    }

    private void TryAtack()
    {
        IsAtack?.Invoke(false);

        if (Input.GetMouseButton(ValueOfLeftClickMouse))
            IsAtack?.Invoke(true);
    }
}
