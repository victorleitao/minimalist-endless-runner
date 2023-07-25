using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSpawner : MonoBehaviour
{
    public Transform player;
    public List<GameObject> hppickups;
    public float initialCooldown = 5;
    public float interval = 15;
    public float zOffset = 120;

    private Vector3 nextSpawnPoint;

    public void SpawnHPPickup()
    {
        // Get prefab
        int randomIndex = Random.Range(0, hppickups.Count);
        GameObject prefab = hppickups[randomIndex];

        // Get position
        nextSpawnPoint.x = Random.Range(-2, 3) * 2;
        nextSpawnPoint.y = prefab.transform.position.y;
        nextSpawnPoint.z = player.position.z + zOffset;

        // Get rotation
        Quaternion rotation = prefab.transform.rotation;

        // Instantiate random resource
        Instantiate(prefab, nextSpawnPoint, rotation);
        SpawnerManager.Instance.canSpawnTime = false;
    }

    void FixedUpdate()
    {
        // Ensure game is active
        if (!GameManager.Instance.isGameActive)
        {
            return;
        }

        // Spawning initialCooldown
        initialCooldown -= PlayerController.Instance.spawningCooldown;
        if (initialCooldown <= 0 && SpawnerManager.Instance.canSpawnTime)
        {
            initialCooldown = interval;
            SpawnHPPickup();
        }
    }
}
