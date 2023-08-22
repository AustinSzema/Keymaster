using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private enum Direction { Up, Down, Left, Right };
    [SerializeField] private Direction _direction;

    [SerializeField] private float _waitTime = 1.0f;   // Time to wait at each position

    private Vector3 _offset = Vector3.zero;

    private Vector3 _originalPos;

    private void Start()
    {
        _originalPos = _enemyTransform.position;
        switch (_direction)
        {
            case Direction.Up:
                _offset = Vector3.up;
                break;
            case Direction.Down:
                _offset = Vector3.down;
                break;
            case Direction.Left:
                _offset = Vector3.left;
                break;

            case Direction.Right:
                _offset = Vector3.right;
                break;
        }

        // Start the movement coroutine
        StartCoroutine(MoveEnemy());
    }

    private IEnumerator MoveEnemy()
    {
        while (true)
        {
            Move(Vector3.Distance(_enemyTransform.position, _originalPos) < 0.01f);
            yield return new WaitForSeconds(_waitTime);
        }

    }

    private void Move(bool atOriginalPos)
    {

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
