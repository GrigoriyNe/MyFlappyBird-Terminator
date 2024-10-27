using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] protected CanvasGroup WindowGroup;
    [SerializeField] protected Button ActionButton;

    public event Action ButtonClicked;

    private void OnEnable()
    {
        ActionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        ActionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    public void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    protected void OnButtonClick()
    {
        ButtonClicked?.Invoke();
    }
}
