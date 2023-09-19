using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private enum Direction { Up, Down, Left, Right };
    [SerializeField] private Direction _direction;

    [SerializeField] private float _waitTime = 1.0f;   // Time to wait at each position

    private Vector3 _offset = Vector3.zero;

    private Vector3 _originalPos;

    [Header("Color Stuff")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _upColor;
    [SerializeField] private Color _downColor;
    [SerializeField] private Color _leftColor;
    [SerializeField] private Color _rightColor;

    private void Start()
    {
        _originalPos = _enemyTransform.position;
        switch (_direction)
        {
            case Direction.Up:
                AssignValues(Vector3.up, _upColor);
                break;
            case Direction.Down:
                AssignValues(Vector3.down, _downColor);
                break;
            case Direction.Left:
                AssignValues(Vector3.left, _leftColor);
                break;

            case Direction.Right:
                AssignValues(Vector3.right, _rightColor);
                break;
        }

        // Start the movement coroutine
    }

    private void AssignValues(Vector3 direction, Color color)
    {
        _offset = direction;
        _spriteRenderer.color = color;
    }


    public void Move()
    {
        bool atOriginalPos = Vector3.Distance(_enemyTransform.position, _originalPos) < 0.01f;

        float moveDirection = atOriginalPos ? 1.0f : -1.0f;

        float rotation = 0f;

        _enemyTransform.position += _offset * moveDirection;
        
        switch (_direction)
        {
            case Direction.Up:
                rotation = atOriginalPos ? 0f : 180f;
                break;
            case Direction.Down:
                rotation = atOriginalPos ? 180f : 0f;
                break;
            case Direction.Left:
                rotation = 90f * moveDirection;
                break;
            case Direction.Right:
                rotation = -90f * moveDirection;
                break;
        }

        _enemyTransform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
    }
}
