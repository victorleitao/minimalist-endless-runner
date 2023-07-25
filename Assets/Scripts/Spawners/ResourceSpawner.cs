using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public Transform player;
    public List<GameObject> resources;
    public float initialCooldown = 5;
    public float interval = 5;
    public float zOffset = 120;

    private Vector3 nextSpawnPoint;

    public void SpawnResource()
    {
        // Get prefab
        int randomIndex = Random.Range(0, resources.Count);
        GameObject prefab = resources[randomIndex];

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
            SpawnResource();
        }
    }
}
