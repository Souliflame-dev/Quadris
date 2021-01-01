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

    public void ShowGameOverAndSwitchScene()
    {
        gameoverText.SetActive(true);
    }


}
