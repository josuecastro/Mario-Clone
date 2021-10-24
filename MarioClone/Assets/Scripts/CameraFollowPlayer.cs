using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float posX;
    [SerializeField] private float posY;
    [SerializeField] private float posZ;

    void Start() {
        posX = 10;
        posY = 10;
        posZ = -10;
    }

    void FixedUpdate () {
        transform.position = new Vector3(target.position.x + posX, target.position.y + posY, target.position.z + posZ);
        //transform.position = new Vector3(target.position.x + posX, target.position.y + posY, target.position.y + posZ);
    }
}
