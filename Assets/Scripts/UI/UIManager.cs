using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject fadeScreen;
    public bool inGame;
    Animator fadeAnim;
    FadeScreen fadeScene;

    private void Start() {
        fadeAnim = fadeScreen.GetComponent<Animator>(); 
        fadeScene = fadeScreen.GetComponent<FadeScreen>();
    }

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
        fadeScene.scene = scene;
        fadeAnim.SetTrigger("Fade");
        // SceneManager.LoadScene(scene);
    }

    public void Continue() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit() {
        Application.Quit();
    }
}
