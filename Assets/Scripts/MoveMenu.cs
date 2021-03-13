using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveMenu : MonoBehaviour
{
    public int menuNum { get; private set; } = 0;

    public int selectMenuSize = 50;
    public int baseMenuSize = 30;

    public GameObject[] menu;
    public string[] sceneNames;

    void Awake()
    {
        if(menu.Length > 0)
        {
            menu[menuNum].GetComponent<Text>().fontSize = selectMenuSize;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (menu.Length > 0)
        {
            moveMenu();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(sceneNames[menuNum]);
            }
        }
        else if (menu.Length == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MaintitleScene");
            }
        }
    }

    private void moveMenu()
    {
        int previousMenuNum = menuNum;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuNum++;
            if (menuNum >= menu.Length)
            {
                menuNum = menuNum & 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuNum--;
            if (menuNum < 0)
            {
                menuNum = menu.Length - 1;
            }
        }

        if ((menuNum ^ previousMenuNum) != 0)
        {
            menu[menuNum].GetComponent<Text>().fontSize = selectMenuSize;
            menu[previousMenuNum].GetComponent<Text>().fontSize = baseMenuSize;
        }
    }
}
