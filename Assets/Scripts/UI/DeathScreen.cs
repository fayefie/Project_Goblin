using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] TMP_Text menuHighScore;
    [SerializeField] private GameObject deathScreenPanel;

    private void Awake()
    {
        deathScreenPanel.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowDeathMenu()
    {
        deathScreenPanel.SetActive(true);
        Time.timeScale = 0f;
        int highScoreAsInt = Mathf.FloorToInt(UIScore.highScore);
        menuHighScore.text = ("High Score: " + highScoreAsInt);
    }
}
