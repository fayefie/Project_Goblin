using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    static public float elapsedTime;
    [SerializeField] TextMeshProUGUI timerText;

    private void Awake()
    {
        elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
