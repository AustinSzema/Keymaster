/*using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform _destination;


    private bool _canTeleport = true;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer(collision.gameObject);
            *//*GameObject player = collision.gameObject;
            if (_canTeleport)
            {
                _canTeleport = false;
                if (Vector3.Distance(player.transform.position, _blueTele.transform.position) < Mathf.Epsilon && _canTeleport)
                {
                    player.transform.position = _orangeTele.transform.position;
                }
                else
                {
                    player.transform.position = _blueTele.transform.position;
                }
            }*//*

        }
    }

    private void TeleportPlayer(GameObject player)
    {
        Vector3 newPosition = _destination.position;
        _destination = (_destination == transform) ? null : _destination;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;

            if (Vector3.Distance(player.transform.position, _blueTele.transform.position) < Mathf.Epsilon)
            {
                _canTeleport = true;
            }
        }
    }
}

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destinationTeleporter; // The destination teleporter

    private bool isTeleporting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTeleporting)
        {
            isTeleporting = true;
            collision.transform.position = destinationTeleporter.position;
            StartCoroutine(ResetTeleportState());
        }
    }

    private IEnumerator ResetTeleportState()
    {
        yield return new WaitForSeconds(2f); // Add a small delay before allowing teleport again
        isTeleporting = false;
    }
}
