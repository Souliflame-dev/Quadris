using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMino : MonoBehaviour
{
    private static int GRID_HEIGHT = 20;
    private static int GRID_WIDTH = 10;
    private static Transform[,] GRID = new Transform[GRID_WIDTH, GRID_HEIGHT];

    public int minoLength = 4;

    public Vector3 rotatePoint;

    private float previousTime = 0;

    private GameLevel gameLevel;
    private SpawnMino spawnMino;
    private Scoring scoring;

    private void Awake()
    {
        gameLevel = FindObjectOfType<GameLevel>();
        spawnMino = FindObjectOfType<SpawnMino>();
        scoring = FindObjectOfType<Scoring>();
    }

    // Update is called once per frame
    void Update()
    {
        moveMino();
    }

    public bool IsValidMove()
    {
        foreach (Transform children in transform)
        {
            int x = Mathf.RoundToInt(children.position.x);
            int y = Mathf.RoundToInt(children.position.y);

            if (x < 0 || x >= GRID_WIDTH || y < 0 || y >= GRID_HEIGHT)
            {
                return false;
            }

            if (GRID[x, y] != null)
            {
                return false;
            }
        }

        return true;
    }

    private void moveMino()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        int level = gameLevel.level;
        if (Time.time - previousTime > gameLevel.fallTimes[level] || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                checkGrid();
            }
            previousTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            while (IsValidMove())
            {
                transform.position += new Vector3(0, -1, 0);
            }
            transform.position -= new Vector3(0, -1, 0);
            checkGrid();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotatePoint), new Vector3(0, 0, 1), -90);

            int minoPosition = (transform.position.x < 5) ? 1 : -1;
            if (!IsValidMove())
            {
                bool bIsValid = false;

                for (int i = 1; i <= minoLength / 2; ++i)
                {
                    transform.position += new Vector3(i * minoPosition, 0, 0);
                    if (IsValidMove())
                    {
                        bIsValid = true;
                        break;
                    }
                    else
                    {
                        transform.position -= new Vector3(i * minoPosition, 0, 0);
                    }
                }

                for (int i = 1; i <= minoLength / 2; ++i)
                {
                    transform.position += new Vector3(0, i * -1, 0);
                    if (IsValidMove())
                    {
                        bIsValid = true;
                        break;
                    }
                    else
                    {
                        transform.position += new Vector3(0, i, 0);
                    }
                }

                if (!bIsValid)
                {
                    transform.RotateAround(transform.TransformPoint(rotatePoint), new Vector3(0, 0, 1), 90);
                }
            }
        }
    }

    private void checkGrid()
    {
        addToGrid();
        checkForLines();
        this.enabled = false;
        gameLevel.movesCount++;
        gameLevel.CheckLevelThreshold();
        spawnMino.MoveMinoToSpawnPoint();
        spawnMino.SpawnPreviewMino();
    }

    private void addToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            GRID[roundedX, roundedY] = children;
        }
    }

    private void checkForLines()
    {
        int scoringRowCount = 0;
        for (int i = GRID_HEIGHT - 1; i >= 0; --i)
        {
            if (hasLine(i))
            {
                deleteLine(i);
                rowDown(i);
                scoringRowCount++;
            }
        }
        scoring.UpdateScore(scoringRowCount);
    }

    private bool hasLine(int i)
    {
        for (int j = 0; j < GRID_WIDTH; ++j)
        {
            if (GRID[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    private void deleteLine(int i)
    {
        for (int j = 0; j < GRID_WIDTH; ++j)
        {
            Destroy(GRID[j, i].gameObject);
            GRID[j, i] = null;
        }
    }

    private void rowDown(int i)
    {
        for (int y = i + 1; y < GRID_HEIGHT; y++)
        {
            for (int x = 0; x < GRID_WIDTH; x++)
            {
                if (GRID[x, y] != null)
                {
                    GRID[x, y - 1] = GRID[x, y];
                    GRID[x, y] = null;
                    GRID[x, y - 1].transform.position += new Vector3(0, -1, 0);
                }
            }
        }
    }
}
