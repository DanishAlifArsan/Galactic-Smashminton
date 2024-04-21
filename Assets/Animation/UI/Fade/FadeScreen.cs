using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private UIManager uIManager;
    Animator fadeAnim;
    int scene;

    private void Start() {
        fadeAnim = GetComponent<Animator>(); 
    }

    public void InteractButton(int status) {
        bool btnStatus = Convert.ToBoolean(status);
        foreach (var item in buttons)
        {
            item.interactable = btnStatus;
        }
        uIManager.canEsc = btnStatus;
    }

    public void Fade(int scene) {
        fadeAnim.SetTrigger("Fade");
        this.scene = scene;
    }

    public void SwitchScene() {
        SceneManager.LoadScene(scene);
    }
}
