using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int score { get; private set; } = 0;
    private int baseScore = 10;
    public GameObject scoreText;

    public void UpdateScore(int scoringRowCount)
    {
        int gettingScore = 0;

        for (int i = 1; i <= scoringRowCount; ++i)
        {
            gettingScore += (int)(baseScore * (i * 1.5));
        }

        score += gettingScore;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
