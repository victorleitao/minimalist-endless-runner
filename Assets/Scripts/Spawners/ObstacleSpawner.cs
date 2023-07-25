using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;
    public float initialCooldown = 5;
    public float interval = 5.5f;
    public float zOffset = 120;

    [HideInInspector]
    public float yAxisSpawnPosition = 0.5f;

    // Choose max lines of obstacles
    public int maxNumberOfObstacles;

    // Obstacles lists
    public List<GameObject> oneLineObstacles;
    public List<GameObject> twoLinesObstacles;
    public List<GameObject> threeLinesObstacles;
    public List<GameObject> fourLinesObstacles;

    private Vector3 nextSpawnPoint;
    private int numberOfObstacles;

    public void SpawnObstacle()
    {
        // Get Z position
        nextSpawnPoint.z = player.position.z + zOffset;
        nextSpawnPoint.y = yAxisSpawnPosition;

        numberOfObstacles = Random.Range(1, maxNumberOfObstacles + 1);

        switch (numberOfObstacles)
        {
            case 1:
                // Get prefab
                int randomOneObstacleIndex = Random.Range(0, oneLineObstacles.Count);
                GameObject oneLineObstacle = oneLineObstacles[randomOneObstacleIndex];

                // Get X position
                nextSpawnPoint.x = Random.Range(-2, 3) * 2;

                // Instantiate
                Instantiate(oneLineObstacle, nextSpawnPoint, Quaternion.identity);
                break;
            case 2:
                //Get prefab
                int randomTwoObstacleIndex = Random.Range(0, twoLinesObstacles.Count);
                GameObject twoLinesObstacle = twoLinesObstacles[randomTwoObstacleIndex];

                // Get X position
                nextSpawnPoint.x = 0;

                // Instantiate
                Instantiate(twoLinesObstacle, nextSpawnPoint, Quaternion.identity);
                break;
            case 3:
                //Get prefab
                int randomThreeObstacleIndex = Random.Range(0, threeLinesObstacles.Count);
                GameObject threeLinesObstacle = threeLinesObstacles[randomThreeObstacleIndex];

                // Get X position
                nextSpawnPoint.x = 0;

                // Instantiate
                Instantiate(threeLinesObstacle, nextSpawnPoint, Quaternion.identity);
                break;
            case 4:
                //Get prefab
                int randomFourObstacleIndex = Random.Range(0, fourLinesObstacles.Count);
                GameObject fourLinesObstacle = fourLinesObstacles[randomFourObstacleIndex];

                // Get X position
                nextSpawnPoint.x = 0;

                // Instantiate
                Instantiate(fourLinesObstacle, nextSpawnPoint, Quaternion.identity);
                break;
            default:
                Debug.Log("Choose an interval between 1 and 4.");
                break;
        }
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
            SpawnObstacle();
        }
    }
}
