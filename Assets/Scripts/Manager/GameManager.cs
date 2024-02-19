using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        RoundStart();
    }

    public void RoundStart() {
        currentGamePhase = GamePhase.Serve;
        AudioManager.instance.PlaySound(refreeSound);
    }

    public void RoundEnd() {
        currentGamePhase = GamePhase.Score;
        AudioManager.instance.PlaySound(crowdSound);
    }
}

public enum GamePhase
{
    Serve,
    Play,
    End,
    Score
}