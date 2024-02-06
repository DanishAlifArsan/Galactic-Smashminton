using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        currentGamePhase = GamePhase.Serve;
    }
}

public enum GamePhase
{
    Serve,
    Play,
    End
}