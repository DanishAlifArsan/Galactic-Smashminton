using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool canEsc;
    public Action OnEscPressed;

    private void Update() {
        if (Input.GetKey(KeyCode.Escape) && canEsc)
        {
            OnEscPressed?.Invoke();
        }
    }

    public void SwitchScene(int scene) {
        SceneManager.LoadScene(scene);
    }
}
