using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMino : MonoBehaviour
{
    public GameObject[] minos = new GameObject[7];
    public GameObject previewPoint;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPreviewMino()
    {
        GameObject mino = Instantiate(minos[Random.Range(0, minos.Length)], previewPoint.transform.position, Quaternion.identity, previewPoint.transform);
        mino.GetComponent<ActionMino>().enabled = false;
    }
    public void moveMinoToSpawnPoint()
    {
        Transform mino = previewPoint.transform.GetChild(0);
        mino.transform.position = spawnPoint.transform.position;
        mino.GetComponent<ActionMino>().enabled = true;
        mino.SetParent(spawnPoint.transform);
        if (!mino.GetComponent<ActionMino>().isValidMove())
        {
            //game over 스크립트로 간다
        }
    }
    void bagMino()
    {

    }


}
