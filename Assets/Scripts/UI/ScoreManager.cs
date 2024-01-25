using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText, EnemyScoreText;
    [SerializeField] BallController ball;
    [SerializeField] int maxScore;
    [SerializeField] GameObject gameoverScreen;
    [SerializeField] TextMeshProUGUI gameoverText;

    private int playerScore, enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        ball.OnCollideField += Score;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentGamePhase == GamePhase.End)
        {
            StartCoroutine(GameOver());
        }
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

    private IEnumerator GameOver() {
        yield return new WaitForSeconds(1);
        gameoverScreen.SetActive(true);
        if (playerScore > enemyScore)
        {
            gameoverText.text = "You Win!";    
        } else {
            gameoverText.text = "You Lose!";
        }
    }
}
