using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float gameWidth = 8f;

    [HideInInspector]
    public bool isGameActive = true;

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

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ensure game is active
        if (!GameManager.Instance.isGameActive)
        {
            return;
        }

        // Game over
        if (PlayerController.Instance.healthPoints == 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
