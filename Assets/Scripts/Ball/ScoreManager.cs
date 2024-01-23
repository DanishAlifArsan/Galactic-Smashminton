using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText, EnemyScoreText;
    private int playerScore, enemyScore;
    Vector2 initialPos;
    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("PlayerField"))
        {
            enemyScore++;
            EnemyScoreText.text = enemyScore.ToString();
            ResetPosition();
        }
        if (other.gameObject.CompareTag("EnemyField"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
            ResetPosition();
        }
    }

    private void ResetPosition() {
        transform.position = initialPos;
        rb.velocity = Vector2.zero;
    }
}
