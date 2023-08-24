using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteColor : MonoBehaviour
{

    [SerializeField] private Color[] _colors;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.color = _colors[Random.Range(0, _colors.Length - 1)];
    }

}
