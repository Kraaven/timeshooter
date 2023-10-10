using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{

    public void start()
    {
        SceneManager.LoadScene("Game");
    }

    public void leave()
    {
        Application.Quit();
    }
}
