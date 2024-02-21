using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{
    [SerializeField] private GameObject QuitScreen;
    [SerializeField] private UIManager uIManager;

    // Start is called before the first frame update
    private void Start()
    {
        uIManager.OnEscPressed += QuitGame;
    }

    public void QuitGame() {
        QuitScreen.SetActive(true);   
    }

    public void ConfirmQuit() {
        Application.Quit();
    }

    public void CancelQuit() {
        QuitScreen.SetActive(false);
    }
}
