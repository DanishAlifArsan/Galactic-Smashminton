using System;
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

    [SerializeField] PlayerController player;
    [SerializeField] EnemyAI enemy;
    CharController character;
    [SerializeField] Transform indicator;

    private Transform playerServePoint, enemyServePoint, currentServePoint;

    // Start is called before the first frame update
    void Start()
    {
        ball.OnCollideField += Score;
        ball.BallPosition += GetServePoint;
        playerServePoint = player.servePoint;
        enemyServePoint = enemy.servePoint;
        currentServePoint = playerServePoint;
        SetIndicator(player);
    }

    private void Score(object sender, BallController.OnCollideFieldArgs args) {
        switch (args.tag)
        {
            case "player" :
                enemyScore++;
                EnemyScoreText.text = enemyScore.ToString();
                currentServePoint = enemyServePoint;
                character = enemy;
                break;
            case "enemy" :
                playerScore++;
                playerScoreText.text = playerScore.ToString();
                currentServePoint = playerServePoint;
                character = player;
                break;
        }
        StartCoroutine(Score(character));
    }

    private IEnumerator Score(CharController character) {
        GameManager.instance.RoundEnd();
        yield return new WaitForSeconds(1);

        if (Mathf.Abs(enemyScore - playerScore) >= 2 && (enemyScore >= maxScore || playerScore >= maxScore))
        {
            GameManager.instance.currentGamePhase = GamePhase.End;
            GameOver();
        } else {
            SetIndicator(character);
            GameManager.instance.RoundStart();
        }
    }

    private Transform GetServePoint() {
        return currentServePoint;
    }

    private void SetIndicator(CharController character) {
        indicator.gameObject.SetActive(true);
        indicator.parent = character.obj.transform;
        indicator.position = character.swing.smashPoint.position;
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
