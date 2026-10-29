using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] TMP_Text menuHighScore;

    private void OnEnable()
    {
        int highScoreAsInt = Mathf.FloorToInt(UIScore.highScore);
        menuHighScore.text = ("High Score: " + highScoreAsInt);
    }

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
