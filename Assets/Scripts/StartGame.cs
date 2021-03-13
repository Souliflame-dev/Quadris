using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject startText;

    private SpawnMino spawnMino;
    private GameLevel gameLevel;

    private void Awake()
    {
        spawnMino = GetComponent<SpawnMino>();
        gameLevel = GetComponent<GameLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGame();
        }
    }

    private void startGame()
    {
        startText.SetActive(false);
        spawnMino.SpawnPreviewMino();
        spawnMino.MoveMinoToSpawnPoint();
        spawnMino.SpawnPreviewMino();
        gameLevel.CheckLevelThreshold();
        enabled = false;
    }
}
