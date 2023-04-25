using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _button_clip;

    public void StartGame() {
        SoundManager.Instance.PlaySound(_button_clip);
        SceneManager.LoadScene(sceneName:"ARScene"); // Start the game
    }

    public void ExitGame() {
        SoundManager.Instance.PlaySound(_button_clip);
        Application.Quit();
    }

    public void OpenMainMenu() {
        SceneManager.LoadScene(sceneName:"MainMenu"); // Open the main menu
    }
}
