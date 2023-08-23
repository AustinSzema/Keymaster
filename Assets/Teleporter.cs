using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    public TeleportTracker _TeleportTracker;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_TeleportTracker._canTeleport)
            {
                Debug.Log("teleported");
                GameObject player = collision.gameObject;
                player.transform.position = _destination.position;
                Debug.Log(_destination.position);
                _TeleportTracker._canTeleport = false;
            }

        }
    }

}
