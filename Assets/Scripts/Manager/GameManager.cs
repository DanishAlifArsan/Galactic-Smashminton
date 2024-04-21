using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject battleStartUI;
    [SerializeField] private GameObject timeline;
    [SerializeField] private AudioClip crowdSound;
    [SerializeField] private AudioClip refreeSound;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    public GamePhase currentGamePhase;

    public void RoundStart() {
        currentGamePhase = GamePhase.Serve;
        battleStartUI.SetActive(false);
        timeline.SetActive(false);
        AudioManager.instance.PlaySound(refreeSound);
    }

    public void RoundEnd() {
        currentGamePhase = GamePhase.Score;
        AudioManager.instance.PlaySound(crowdSound);
    }

    public bool IsPlayPhase() {
        return currentGamePhase == GamePhase.Play || currentGamePhase == GamePhase.Score;
    }
}

public enum GamePhase
{
    Serve,
    Play,
    Score,
    End
}