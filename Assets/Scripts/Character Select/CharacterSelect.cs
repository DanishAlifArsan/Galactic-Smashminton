using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private PlayableCharacter[] characters;
    public PlayableCharacter selectedCharacter {get; private set;}
    public static CharacterSelect instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter(int characterIndex) {
        selectedCharacter = characters[characterIndex];
        SceneManager.LoadScene(2);
    }
}
