using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallsInLava : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other) {
        if (other == player) {
            print("dead");
        }
    }
}