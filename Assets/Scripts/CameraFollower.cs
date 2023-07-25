using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        targetPosition = player.position + offset;
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
