using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverText;
    public string titleSceneName = "MaintitleScene";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(titleSceneName);
        }
    }

    public void ProcessGameover()
    {
        int score = FindObjectOfType<Scoring>().score;
        FindObjectOfType<HandleScorefile>().SaveScoreData(score);
        gameoverText.SetActive(true);
    }


}
