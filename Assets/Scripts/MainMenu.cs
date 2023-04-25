using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(sceneName:"ARScene"); // Start the game
    }

    public void ExitGame() {
        Application.Quit();
    }
}
