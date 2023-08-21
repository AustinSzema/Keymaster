using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockKey : MonoBehaviour
{
    [SerializeField] private IntVariable _keyCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            _keyCount.Value++;
            gameObject.SetActive(false);
        }
    }
}
