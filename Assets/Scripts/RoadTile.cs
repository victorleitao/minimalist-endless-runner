using UnityEngine;

public class RoadTile : MonoBehaviour
{
    public RoadTile Instance { get; private set; }
    TileSpawner tileSpawner;

    void Start()
    {
        tileSpawner = GameObject.FindObjectOfType<TileSpawner>();
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        tileSpawner.SpawnTile();
        Destroy(gameObject, 1);
    }

}
