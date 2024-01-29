using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    public bool inGame;

    private void Update() {
        if (!inGame)
        {
            Time.timeScale = 1;
            return;
        }

        if (Input.GetKey(KeyCode.Escape) && GameManager.instance.currentGamePhase != GamePhase.End)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }    
    }

    public void SwitchScene(int scene) {
        SceneManager.LoadScene(scene);
    }

    public void Continue() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit() {
        Application.Quit();
    }
}
