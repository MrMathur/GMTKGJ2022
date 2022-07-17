using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(2);
    }
    public void OpenCredits() {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void OpenChooseLevel() {
        SceneManager.LoadScene(1);
    }

    public void OpenMainMenu() {
        SceneManager.LoadScene(0);
    }
}
