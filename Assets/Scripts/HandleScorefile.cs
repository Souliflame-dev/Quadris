using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HandleScorefile : MonoBehaviour
{
    private const string PATH = "Assets/Datafile/score.txt";
    private const char SPLIT_CHAR = ',';
    private const int SCORE_COUNT = 10;

    public int[] LoadScoreData()
    {
        return null;
    }

    public void CheckValidFile()
    {
        //경로를 체크해서 파일이 없으면 새로운 파일을 만든다.
        if (!File.Exists(PATH))
        {
            Debug.Log($"{PATH}: Score textfile doesn't exists.");
            createScorefile(false);
        }

        //체크해서 파일이 있는데 데이터를 검증해서 검증값이 이상하면 새로 파일을 만든다.
        //checkValidData();
        Debug.Log($"{PATH}: Score textfile exists.");
        return;
    }

    private void createScorefile(bool hasWrongData)
    {
        if (hasWrongData)
        {
            Debug.Log($"{PATH}: Wrong data found and delete file");
            File.Delete(PATH);
        }

        using (StreamWriter sw = File.CreateText(PATH))
        {
            for (int i = SCORE_COUNT; i >= 1; --i)
            {
                sw.Write($"{1000 * i}");
                if (i == 1)
                {
                    break;
                }
                sw.Write($"{SPLIT_CHAR}");
            }
        }
        Debug.Log($"{PATH}: Create new scorefile");
    }
}
