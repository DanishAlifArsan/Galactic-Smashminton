using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject fadeScreen;
    [SerializeField] private Button[] buttons;
    public bool inGame;
    Animator fadeAnim;
    FadeScreen fadeScene;

    private void Start() {
        fadeAnim = fadeScreen.GetComponent<Animator>(); 
        fadeScene = fadeScreen.GetComponent<FadeScreen>();
        InteractButton(true);
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

    public void SwitchScene(int scene) 
    {
        InteractButton(false);    
        fadeScene.scene = scene;
        fadeAnim.SetTrigger("Fade");
    }

    public void Continue() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit() {
        Application.Quit();
    }

    public void InteractButton(bool status) {
        foreach (var item in buttons)
        {
            item.interactable = status;
        }
    }
}
