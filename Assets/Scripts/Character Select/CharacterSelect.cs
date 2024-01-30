using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private PlayableCharacter[] characters;
    [SerializeField] private GameObject fadeScreen;
    public PlayableCharacter selectedCharacter {get; private set;}
    public static CharacterSelect instance;
    Animator fadeAnim;
    FadeScreen fadeScene;

    private void Awake() {
        if (instance == null) {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);
 
        } else if (instance != this) {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        fadeAnim = fadeScreen.GetComponent<Animator>(); 
        fadeScene = fadeScreen.GetComponent<FadeScreen>();
    }

    public void SelectCharacter(int characterIndex) {
        selectedCharacter = characters[characterIndex];
        fadeScene.scene = 2;
        fadeAnim.SetTrigger("Fade");
        // SceneManager.LoadScene(2);
    }
}