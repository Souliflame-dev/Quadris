using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class HandleScorefile : MonoBehaviour
{
    private const string PATH = "Assets/Datafile/score.txt";
    private const char SPLIT_CHAR = ',';
    private const int SCORE_COUNT = 10;

    public void SaveScoreData(int score)
    {
        int[] scoreData = LoadScoreData();
        bool isChanged = false;

        int temp;
        for (int i = 0; i < scoreData.Length; ++i)
        {
            if (scoreData[i] < score)
            {
                temp = scoreData[i];
                scoreData[i] = score;
                score = temp;
                isChanged = true;
            }
        }

        if (isChanged)
        {
            using (StreamWriter sw = new StreamWriter(PATH, false))
            {
                sw.Flush();
                for (int i = 0; i < scoreData.Length; ++i)
                {
                    sw.Write(scoreData[i].ToString());
                    if (i == scoreData.Length - 1)
                    {
                        break;
                    }
                    sw.Write(SPLIT_CHAR);
                }
                sw.Close();
            }
        }
    }

    public int[] LoadScoreData()
    {
        int[] scoreData = new int[SCORE_COUNT];

        if (!VerifyValidFile(scoreData))
        {
            Debug.Log($"{PATH}: Has wrong data, create new");
            createScorefile();
            VerifyValidFile(scoreData);
        }

        Debug.Log("SUCCESS: Load score data");
        return scoreData;
    }

    public bool VerifyValidFile(int[] scoreData)
    {
        if (!File.Exists(PATH))
        {
            return false;
        }

        string[] source = File.ReadAllText(PATH).Split(SPLIT_CHAR);
        if (source == null || source.Length != SCORE_COUNT)
        {
            return false;
        }

        int temp = 0;
        try
        {
            for (int i = SCORE_COUNT - 1; i >= 0; --i)
            {
                int score = Int32.Parse(source[i]);
                if (score < temp)
                {
                    Debug.LogError($"{PATH}: Has wrong data");
                    File.Delete(PATH);
                    return false;
                }
                scoreData[i] = score;
                temp = score;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            Debug.LogError($"{PATH}: Has wrong data");
            File.Delete(PATH);
            return false;
        }

        return true;
    }

    private void createScorefile()
    {
        using (StreamWriter sw = File.CreateText(PATH))
        {
            for (int i = SCORE_COUNT; i >= 1; --i)
            {
                sw.Write($"{100 * i}");
                if (i == 1)
                {
                    break;
                }
                sw.Write($"{SPLIT_CHAR}");
            }
            sw.Close();
        }
        Debug.Log($"{PATH}: Create new scorefile");
    }
}
