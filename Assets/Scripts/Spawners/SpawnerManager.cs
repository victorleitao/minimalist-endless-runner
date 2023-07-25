using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance { get; private set; }

    // 0.1 = 4z units
    public float timeTolerance = 0.5f;

    // Cooldown variables
    private float initialCooldown = 0;

    [HideInInspector]
    public bool canSpawnTime;

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
        canSpawnTime = false;
    }

    void FixedUpdate()
    {
        initialCooldown -= Time.fixedDeltaTime;
        if (initialCooldown <= 0)
        {
            initialCooldown = timeTolerance;
            canSpawnTime = true;
        }
    }
}
