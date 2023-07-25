using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private GameObject player;

    // Zombie speed towards player
    [SerializeField]
    private float zombieSpeed = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = PlayerController.Instance.gameObject;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, zombieSpeed * Time.fixedDeltaTime);
        transform.forward = player.transform.position - transform.position;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
