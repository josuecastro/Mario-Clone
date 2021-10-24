using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        // player.transform.parent = transform;
        if (other.gameObject == player)
        {
            print("Player entered trigger");
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            print("Player exited trigger");
            player.transform.parent = null;
        }
    }
}
