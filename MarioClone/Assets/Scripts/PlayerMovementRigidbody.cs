using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRigidbody : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody rb;

    [Header("Grounded Check Variables")]
    [SerializeField] private Transform groundCheckBack;
    [SerializeField] private Transform groundCheckFront;
    [SerializeField] private LayerMask ground;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
