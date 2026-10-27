using TMPro;
using UnityEngine;

public class UIKillCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killCounterText;

    private void Awake()
    {
        
    }

    private void Start()
    {
        killCounterText.text = "0";
    }

    void Update()
    {
        KillCounter();
    }

    private void KillCounter()
    {
        killCounterText.text = EnemyBehaviour.enemyKillCounter.ToString();
    }
}
