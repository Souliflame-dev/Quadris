using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HandleDatafile : MonoBehaviour
{
    private string path = "Assets/Datafile/score.txt";
    private const char SPLIT_CHAR = ',';
    private const int SCORE_COUNT = 10;

    public void SaveScoreData(int score)
    {
        checkValidPath();

        int[] highScores = LoadScoreData();
        int scoreIndex = -1;

        for (int i = highScores.Length - 1; i >= 0; --i)
        {
            if (score <= highScores[i])
            {
                break;
            }
            else
            {
                scoreIndex = i;
            }
        }

        if (scoreIndex == -1)
        {
            return;
        }

        int tempScore;
        for (int i = scoreIndex; i < highScores.Length; ++i)
        {
            tempScore = highScores[i];
            highScores[i] = score;
            score = tempScore;
        }

        StreamWriter sw = new StreamWriter(path, false);
        for (int i = 0; i < highScores.Length; ++i)
        {
            sw.Write(highScores[i].ToString());
            if (i == highScores.Length - 1)
            {
                break;
            }
            sw.Write($"{SPLIT_CHAR}");
        }
        sw.Close();
    }

    public int[] LoadScoreData()
    {
        checkValidPath();
        StringReader sr = new StringReader(path);
        string source = sr.ReadLine();

        string[] stringScore = null;

        while (source != null)
        {
            stringScore = source.Split(SPLIT_CHAR);
            if (stringScore.Length == 0)
            {
                sr.Close();
                return transStringArrayToIntArray(stringScore);
            }
            source = sr.ReadLine();
        }

        return transStringArrayToIntArray(stringScore);
    }

    private int[] transStringArrayToIntArray(string[] stringScore)
    {
        int[] intScore = new int[stringScore.Length];

        for (int i = 0; i < intScore.Length; ++i)
        {
            Int32.TryParse(stringScore[i], out intScore[i]);
        }

        return intScore;
    }

    private void checkValidPath()
    {
        if (!File.Exists(path))
        {
            Debug.LogError("score txt file doesn't exist");
            createSavefile();
        }
    }

    private void createSavefile()
    {
        File.Create(path);
        StreamWriter writer = new StreamWriter(path, true);

        for (int i = SCORE_COUNT; i >= 1; --i)
        {
            writer.Write($"{1000 * i}");
            if (i == 1)
            {
                break;
            }
            writer.Write($"{SPLIT_CHAR}");
        }

        writer.Close();

        Debug.LogError($"create savefile to {path}");
    }


}
