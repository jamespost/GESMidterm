using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //current scene name
    public string sceneName;
    private Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }
    //load the game scene
    public void LoadGameScene()
    {
        //if the current scene is the main menu, load the tutorial
        if (sceneName == "MainMenu")
        {
            SceneManager.LoadScene("tutorial scene");
        }
        //if the current scene is the tutorial, load level 1
        if (sceneName == "tutorial scene")
        {
            SceneManager.LoadScene("level 1");
        }

        //if the current scene is level 1, load the final level
        if (sceneName == "level 1")
        {
            SceneManager.LoadScene("Final level");
        }

        //if the current scene is the final level, load the tutorial
        if (sceneName == "Final level")
        {
            SceneManager.LoadScene("tutorial scene");
        }        
    }
}
