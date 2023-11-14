using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadSceneMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void loadSceneGlobalChat()
    {
        SceneManager.LoadScene(2);
    }

    public void loadSceneGroupChat()
    {
        SceneManager.LoadScene(3);
    }

    public void loadSceneNewMassage()
    {
        SceneManager.LoadScene(4);
    }
}