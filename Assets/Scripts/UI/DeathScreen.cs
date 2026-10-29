using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] TMP_Text menuHighScore;

    private void Awake()
    {
        gameObject.SetActive(false);
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
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        int highScoreAsInt = Mathf.FloorToInt(UIScore.highScore);
        menuHighScore.text = ("High Score: " + highScoreAsInt);
    }
}
