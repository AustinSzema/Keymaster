using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportChecker : MonoBehaviour
{
    [SerializeField] private TeleportTracker _TeleportTracker;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _TeleportTracker._canTeleport = true;
        }
    }
}
