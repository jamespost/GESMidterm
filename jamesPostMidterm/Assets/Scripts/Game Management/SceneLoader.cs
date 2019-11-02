using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //load the game scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game Level");
    }
}
