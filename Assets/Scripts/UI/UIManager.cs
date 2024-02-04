using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeScreen;
    [SerializeField] private Button[] buttons;
    private bool canEsc;
    Animator fadeAnim;
    FadeScreen fadeScene;
    public Action OnEscPressed;

    private void Start() {
        fadeAnim = fadeScreen.GetComponent<Animator>(); 
        fadeScene = fadeScreen.GetComponent<FadeScreen>();
        InteractButton(true);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape) && canEsc)
        {
            OnEscPressed?.Invoke();
        }
    }

    public void SwitchScene(int scene) 
    {
        InteractButton(false);    
        fadeScene.scene = scene;
        fadeAnim.SetTrigger("Fade");
    }

    public void InteractButton(bool status) {
        foreach (var item in buttons)
        {
            item.interactable = status;
        }
        canEsc = status;
    }
}
