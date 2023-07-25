using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public static TileSpawner Instance { get; private set; }
    public List<GameObject> tiles;
    public List<GameObject> buildingsLeft;
    public List<GameObject> buildingsRight;

    private Vector3 nextSpawnPoint;
    private Vector3 buildingSpawnPoint;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SpawnTile()
    {
        int randomTileIndex = Random.Range(0, tiles.Count);
        GameObject temp = Instantiate(tiles[randomTileIndex], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        SpawnBuildingLeft();
        SpawnBuildingRight();
    }

    public void SpawnBuildingLeft()
    {
        int randomBuildingIndex = Random.Range(0, buildingsLeft.Count);

        // Get temp building
        GameObject tempBuilding = buildingsLeft[randomBuildingIndex];

        // Get rotation
        Quaternion rotation = tempBuilding.transform.rotation;

        // Get position
        buildingSpawnPoint.x = nextSpawnPoint.x + tempBuilding.transform.position.x;
        buildingSpawnPoint.y = nextSpawnPoint.y + tempBuilding.transform.position.y;
        buildingSpawnPoint.z = nextSpawnPoint.z + 2.5f;

        // Instatiate building
        Instantiate(tempBuilding, buildingSpawnPoint, rotation);

        randomBuildingIndex = Random.Range(0, buildingsLeft.Count);

        // Get temp building
        tempBuilding = buildingsLeft[randomBuildingIndex];

        buildingSpawnPoint.z = nextSpawnPoint.z + 7.5f;

        // Instatiate building
        Instantiate(tempBuilding, buildingSpawnPoint, rotation);
    }

    public void SpawnBuildingRight()
    {
        int randomBuildingIndex = Random.Range(0, buildingsRight.Count);

        // Get temp building
        GameObject tempBuilding = buildingsRight[randomBuildingIndex];

        // Get rotation
        Quaternion rotation = tempBuilding.transform.rotation;

        // Get position
        buildingSpawnPoint.x = nextSpawnPoint.x + tempBuilding.transform.position.x;
        buildingSpawnPoint.y = nextSpawnPoint.y + tempBuilding.transform.position.y;
        buildingSpawnPoint.z = nextSpawnPoint.z + 2.5f;

        // Instatiate building
        Instantiate(tempBuilding, buildingSpawnPoint, rotation);

        randomBuildingIndex = Random.Range(0, buildingsRight.Count);

        // Get temp building
        tempBuilding = buildingsRight[randomBuildingIndex];

        buildingSpawnPoint.z = nextSpawnPoint.z + 7.5f;

        // Instatiate building
        Instantiate(tempBuilding, buildingSpawnPoint, rotation);
    }

    void Start()
    {
        for (int i = 0; i < 13; i++)
        {
            SpawnTile();
        }
    }
}