using System.Collections.Generic;
using UnityEngine;

public class SpriteObjectStorage : MonoBehaviour
{
    [SerializeField] private List<Sprite> _view;

    public Sprite GetSprite()
    {
        int valueRandom = Random.Range(0, _view.Count);

        return _view[valueRandom];
    }
}
