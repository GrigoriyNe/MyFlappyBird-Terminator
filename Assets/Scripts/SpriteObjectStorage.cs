using System.Collections.Generic;
using UnityEngine;

public class SpriteObjectStorage : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;

    public Sprite GetSprite()
    {
        int valueRandom = Random.Range(0, _sprites.Count);

        return _sprites[valueRandom];
    }
}
