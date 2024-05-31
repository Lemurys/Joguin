using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject scenesPanel;
    public GameObject initialMenu;
    public GameObject pauseScreen;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseScreen.activeInHierarchy) {
                PauseGame(false);
            }
            else {
                PauseGame(true);
            }
        }
    }

    #region MENU
    public void LoadScene(string cena) {
        SceneManager.LoadScene(cena);
    }

    public void OpenOption() {
        optionPanel.SetActive(true);
        initialMenu.SetActive(false);
    }

    public void CloseOption() {
        optionPanel.SetActive(false);
        initialMenu.SetActive(true);
    }

    public void OpenScenes() {
        scenesPanel.SetActive(true);
        initialMenu.SetActive(false);
    }

    public void CloseScenes() {
        scenesPanel.SetActive(false);
        initialMenu.SetActive(true);
    }

    public void OpenOPGame() {
        optionPanel.SetActive(true);
    }

    public void CloseOPGame() {
        optionPanel.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }

    #endregion MENU

    #region Pause

    private void PauseGame(bool status) {

        pauseScreen.SetActive(status);

        if(status) {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }

    #endregion Pause
}
