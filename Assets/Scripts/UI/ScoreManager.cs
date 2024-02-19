using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText, EnemyScoreText;
    [SerializeField] BallController ball;
    [SerializeField] int maxScore;
    [SerializeField] GameObject gameoverScreen;
    [SerializeField] Image gameoverText; 
    [SerializeField] Sprite winText, loseText;

    private int playerScore, enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        ball.OnCollideField += Score;
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
        StartCoroutine(Score());
    }

    private IEnumerator Score() {
        GameManager.instance.RoundEnd();
        yield return new WaitForSeconds(1);
        if (Mathf.Abs(enemyScore - playerScore) >= 2 && (enemyScore >= maxScore || playerScore >= maxScore))
        {
            GameManager.instance.currentGamePhase = GamePhase.End;
            GameOver();
        } else {
            GameManager.instance.RoundStart();
        }
    }

    private void GameOver() {
        gameoverScreen.SetActive(true);
        if (playerScore > enemyScore)
        {
            gameoverText.sprite = winText; 
        } else {
            gameoverText.sprite = loseText;
        }
    }
}
