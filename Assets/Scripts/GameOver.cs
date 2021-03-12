using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverText;
    public string titleSceneName = "MaintitleScene";

    private Scoring scoring;
    private HandleScorefile handleScoreFile;

    private void Awake()
    {
        scoring = FindObjectOfType<Scoring>();
        handleScoreFile = FindObjectOfType<HandleScorefile>();
    }

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
        int score = scoring.score;
        handleScoreFile.SaveScoreData(score);
        gameoverText.SetActive(true);
    }


}
