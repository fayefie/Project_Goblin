using System.Threading;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    public float playerScore;
    [SerializeField] TextMeshProUGUI scoreText;
    static public float highScore;

    private PlayerStats ps;
    void Start()
    {
        playerScore = 0;
        ps = FindFirstObjectByType<PlayerStats>();
        InvokeRepeating(nameof(PlayerScore), 1f, 1f);
    }

    void Update()
    {

    }

    void PlayerScore()
    {
        float timerSurvivedAsScore = UITimer.elapsedTime * 1.3f;
        float killCountAsScore = EnemyBehaviour.enemyKillCounter * 1.6f;
        float playerLevelAsScore = ps.playerLevel * 2.5f;

        playerScore = timerSurvivedAsScore + killCountAsScore + playerLevelAsScore;
        int scoreAsInt = Mathf.FloorToInt(playerScore);

        scoreText.text = ("Score: " + scoreAsInt);

        Debug.Log(playerScore);
    }
}
