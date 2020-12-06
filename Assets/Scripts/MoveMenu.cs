using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveMenu : MonoBehaviour
{
    public GameObject[] Menu = new GameObject[1];
    public int selectMenuSize = 50;
    public int baseMenuSize = 30;
    public int menuNum { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveMenu();
    }

    void moveMenu()
    {
        int previousMenuNum = menuNum;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuNum++;
            if (menuNum >= Menu.Length)
            {
                menuNum = menuNum & 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuNum--;
            if (menuNum < 0)
            {
                menuNum = Menu.Length - 1;
            }
        }

        if ((menuNum ^ previousMenuNum) != 0)
        {
            Menu[menuNum].GetComponent<Text>().fontSize = selectMenuSize;
            Menu[previousMenuNum].GetComponent<Text>().fontSize = baseMenuSize;
        }
    }
}
