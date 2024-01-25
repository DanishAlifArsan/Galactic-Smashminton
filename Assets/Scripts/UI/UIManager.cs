using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void SwitchScene(int scene) {
        SceneManager.LoadScene(scene);
    }

    public void Exit() {
        Application.Quit();
    }
}
