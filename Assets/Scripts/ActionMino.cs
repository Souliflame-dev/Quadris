using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMino : MonoBehaviour
{
    public Vector3 rotatePoint;
    public float fallTime = 10;
    public int minoLength = 4;
    private static int gridHeight = 20;
    private static int gridWidth = 10;
    private float previousTime = 0;
    private static Transform[,] grid = new Transform[gridWidth, gridHeight];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveMino();
    }

    void moveMino()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!isValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!isValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        if (Time.time - previousTime > fallTime || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!isValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                checkGrid();
            }
            previousTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            while (isValidMove())
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
            if (!isValidMove())
            {
                bool isValid = false;

                for (int i = 1; i <= minoLength / 2; ++i)
                {
                    transform.position += new Vector3(i * minoPosition, 0, 0);
                    if (isValidMove())
                    {
                        isValid = true;
                        break;
                    }
                    else
                    {
                        transform.position -= new Vector3(i * minoPosition, 0, 0);
                    }
                }

                for (int i = 1; i <=minoLength / 2; ++i)
                {
                    transform.position += new Vector3(0, i * -1, 0);
                    if (isValidMove())
                    {
                        isValid = true;
                        break;
                    }
                    else
                    {
                        transform.position -= new Vector3(0, i, 0);
                    }
                }

                if (!isValid)
                {
                    transform.RotateAround(transform.TransformPoint(rotatePoint), new Vector3(0, 0, 1), 90);
                }
            }
        }
    }
    bool isValidMove()
    {
        foreach (Transform children in transform)
        {
            int x = Mathf.RoundToInt(children.position.x);
            int y = Mathf.RoundToInt(children.position.y);

            if (x < 0 || x >= gridWidth || y < 0 || y >= gridHeight)
            {
                return false;
            }

            if (grid[x, y] != null)
            {
                return false;
            }
        }

        return true;
    }

    void checkGrid()
    {
        addToGrid();
        checkForLines();
        this.enabled = false;
        FindObjectOfType<SpawnMino>().moveMinoToSpawnPoint();
        FindObjectOfType<SpawnMino>().spawnPreviewMino();
    }

    void addToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedY > gridHeight)
            {
                Debug.Log("game over");
            }

            grid[roundedX, roundedY] = children;
        }
    }

    void checkForLines()
    {
        int scoringRowCount = 0;
        for (int i = gridHeight - 1; i >= 0; --i)
        {
            if (hasLine(i))
            {
                deleteLine(i);
                rowDown(i);
                scoringRowCount++;
            }
        }
        FindObjectOfType<Scoring>().updateScore(scoringRowCount);
    }

    bool hasLine(int i)
    {
        for (int j = 0; j < gridWidth; ++j)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    void deleteLine(int i)
    {
        for (int j = 0; j < gridWidth; ++j)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void rowDown(int i)
    {
        for (int y = i; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += new Vector3(0, -1, 0);
                }
            }
        }
    }
}
