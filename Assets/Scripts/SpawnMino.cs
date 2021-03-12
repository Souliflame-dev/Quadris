using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMino : MonoBehaviour
{
    public GameObject[] minos = new GameObject[7];
    public GameObject previewPoint;
    public GameObject spawnPoint;

    private GameOver gameOver;

    private void Awake()
    {
        gameOver = FindObjectOfType<GameOver>();
    }

    public void SpawnPreviewMino()
    {
        GameObject mino = Instantiate(minos[Random.Range(0, minos.Length)], previewPoint.transform.position, Quaternion.identity, previewPoint.transform);
        mino.GetComponent<ActionMino>().enabled = false;
    }
    public void MoveMinoToSpawnPoint()
    {
        Transform mino = previewPoint.transform.GetChild(0);
        mino.transform.position = spawnPoint.transform.position;

        if (!mino.GetComponent<ActionMino>().IsValidMove())
        {
            gameOver.ProcessGameover();
            return;
        }

        mino.GetComponent<ActionMino>().enabled = true;
        mino.SetParent(spawnPoint.transform);
    }
}
