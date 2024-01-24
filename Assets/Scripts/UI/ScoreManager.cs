using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText, EnemyScoreText;
    [SerializeField] BallController ball;
    [SerializeField] int maxScore;

    private int playerScore, enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        ball.OnCollideField += Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Score(object sender, BallController.OnCollideFieldArgs args) {
        switch (args.tag)
        {
            case "player" :
                enemyScore++;
                EnemyScoreText.text = enemyScore.ToString();
                break;
            case "enemy" :
                playerScore++;
                playerScoreText.text = playerScore.ToString();
                break;
        }
        if (Mathf.Abs(enemyScore - playerScore) >= 2 && (enemyScore >= maxScore || playerScore >= maxScore))
        {
            GameManager.instance.currentGamePhase = GamePhase.End;
        } else {
            GameManager.instance.currentGamePhase = GamePhase.Serve;
        }
    }
}
