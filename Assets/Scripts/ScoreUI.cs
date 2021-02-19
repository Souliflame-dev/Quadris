using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public GameObject[] scoreTexts = new GameObject[10];
    public string mainSceneName;
    private HandleScorefile handler;

    private void Awake()
    {
        handler = GetComponent<HandleScorefile>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] scores = handler.LoadScoreData();
        for (int i = 0; i < scoreTexts.Length; ++i)
        {
            scoreTexts[i].GetComponent<Text>().text = $"#{i + 1} - {scores[i].ToString()}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene(mainSceneName);

        }
    }
}
