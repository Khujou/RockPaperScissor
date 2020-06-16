using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenBehavior : MonoBehaviour
{

    private Transform menuPointer;

    // Start is called before the first frame update
    void Start()
    {
        menuPointer = this.gameObject.transform.GetChild(0);
        menuPointer.position = new Vector3(-2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MenuPointerFunction();
    }

    void MenuPointerFunction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (menuPointer.position.y == 0)
            {
                movePointer(-2);
            }
            else
            {
                movePointer(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (menuPointer.position.y == -2)
            {
                movePointer(2);
            }
            else
            {
                movePointer(-1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (menuPointer.position.y) {
                case 0:
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                    break;
                case -1:
                    SceneManager.LoadScene(2, LoadSceneMode.Single);
                    break;
                case -2:
                    Application.Quit();
                    break;
            }
        }
    }

    void movePointer(int i)
    {
        menuPointer.position += new Vector3(0, i, 0);
    }
}