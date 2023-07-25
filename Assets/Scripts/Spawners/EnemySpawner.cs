using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public List<GameObject> enemies;
    public float initialCooldown = 5;
    public float interval = 5;
    public float zOffset = 120;

    private Vector3 nextSpawnPoint;

    public void SpawnEnemy()
    {
        // Get prefab
        int randomEnemyIndex = Random.Range(0, enemies.Count);
        GameObject prefab = enemies[randomEnemyIndex];

        // Get position
        nextSpawnPoint.y = prefab.transform.position.y;
        nextSpawnPoint.z = player.position.z + zOffset;
        nextSpawnPoint.x = Random.Range(-2, 3) * 2;

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
            SpawnEnemy();
        }
    }
}
