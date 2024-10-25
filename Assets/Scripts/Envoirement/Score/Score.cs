using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class Score : SpawnerableObject, IInteractable
{
    [SerializeField] private SpriteObjectStorage _images;

    private SpriteRenderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _images.GetSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bat _))
        {
            Return();
        }
    }
}
