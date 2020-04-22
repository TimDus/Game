using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void MenuToHub(int sceneIndex)
    {
        GlobalVariables.Speed = 1;
        GlobalVariables.GameCount = 0;
        GlobalVariables.LastResult = false;
        GlobalVariables.JustPlayed = false;
        SceneManager.LoadScene(sceneIndex);
    }

    public void HubToGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GameToHub(int sceneIndex, bool result)
    {
        GlobalVariables.LastResult = result;
        SceneManager.LoadScene(sceneIndex);
    }
}
