using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public const int MAX_LEVEL = 20;

    public int movesCount { get; set; }

    public int level = 0;
    public int[] movesCountThreshold = new int[MAX_LEVEL];
    public int[] scoreThreshold = new int[MAX_LEVEL];

    public GameObject levelText;

    private Scoring scoring;
    private void Awake()
    {
        scoring = GetComponent<Scoring>();
    }

    public void CheckLevelThreshold()
    {
        if (level == 20)
        {
            return;
        }

        if (isLargerValue(movesCount, movesCountThreshold[level]) || isLargerValue(scoring.score, scoreThreshold[level]))
        {
            level++;
            levelText.GetComponent<UnityEngine.UI.Text>().text = $"LEVEL {level}";
        }
    }

    public int GetMaxLevel()
    {
        return MAX_LEVEL;
    }

    private bool isLargerValue(int currentValue, int nextValue)
    {
        if (currentValue >= nextValue)
        {
            return true;
        }

        return false;
    }
}
