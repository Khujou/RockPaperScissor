using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineScreenBehavior : MonoBehaviour
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
                movePointer(-1);
            }
            else
            {
                movePointer(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (menuPointer.position.y == -1)
            {
                movePointer(1);
            }
            else
            {
                movePointer(-1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (menuPointer.position.y)
            {
                case 0:
                    SceneManager.LoadScene(3, LoadSceneMode.Single);
                    break;
                case -1:
                    SceneManager.LoadScene(4, LoadSceneMode.Single);
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    void movePointer(int i)
    {
        menuPointer.position += new Vector3(0, i, 0);
    }
}
