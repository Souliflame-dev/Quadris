using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject startText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGame();
        }
    }

    void startGame()
    {
        startText.SetActive(false);
        FindObjectOfType<SpawnMino>().spawnPreviewMino();
        FindObjectOfType<SpawnMino>().moveMinoToSpawnPoint();
        FindObjectOfType<SpawnMino>().spawnPreviewMino();
        FindObjectOfType<GameLevel>().checkLevelThreshold();
        enabled = false;
    }
}
