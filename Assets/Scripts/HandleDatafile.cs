using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HandleDatafile : MonoBehaviour
{
    // HandleScoreFile로 대체
    /*
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
        string[] stringScore = null;

        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string source;
                if ((source = sr.ReadLine()) != null)
                {
                    stringScore = source.Split(SPLIT_CHAR);
                }
                return transStringArrayToIntArray(stringScore);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("LoadScoreData Error");
            Debug.LogError(e.Message);
        }

        return transStringArrayToIntArray(stringScore);
    }

    private bool checkValidData(string[] dataArray)
    {
        if (dataArray == null || dataArray.Length != SCORE_COUNT)
        {
            return false;
        }

        for (int i = 0; i < SCORE_COUNT; ++i)
        {
            int temp;
            if(!Int32.TryParse(dataArray[i], out temp))
            {
                return false;
            }
        }

        return true;
    }

    private int[] transStringArrayToIntArray(string[] stringScore)
    {
        if (stringScore == null || stringScore.Length != SCORE_COUNT)
        {
            return null;
        }

        int[] intScore = new int[SCORE_COUNT];

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
            Debug.LogError("Score textfile doesn't exists.");
            createScorefile();
        }
    }

    private void createScorefile()
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
    */
}