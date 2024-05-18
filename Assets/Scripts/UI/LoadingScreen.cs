using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private string[] tips;
    [SerializeField]private TMP_Text tipsText;

    private void Awake() {
        tipsText.text = "Tips: "+ tips[Random.Range(0, tips.Length-1)];
    }
    

    public void LoadingEnd() {
        SceneManager.LoadScene(1);
    }
}
