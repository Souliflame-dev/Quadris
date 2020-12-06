using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int score = 0;
    private int baseScore = 10;

    public void updateScore(int scoringRowCount)
    {
        int gettingScore = 0;

        for (int i = 1; i <= scoringRowCount; ++i)
        {
            gettingScore += (int)(baseScore * (i * 1.5));
        }

        score += gettingScore;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
