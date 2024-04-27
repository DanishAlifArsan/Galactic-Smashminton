using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    [SerializeField] GameObject pauseScreen;

    // Start is called before the first frame update
    private void Start()
    {
       uIManager.OnEscPressed += PauseGame; 
    }

    public void PauseGame() {
        GameManager.instance.isPaused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue() {
        GameManager.instance.isPaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }
}
