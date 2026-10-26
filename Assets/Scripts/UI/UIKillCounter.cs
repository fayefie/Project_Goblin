using TMPro;
using UnityEngine;

public class UIKillCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killCounterText;

    // Update is called once per frame
    void Update()
    {
        KillCounter();
    }

    private void KillCounter()
    {
        killCounterText.text = EnemyBehaviour.enemyKillCounter.ToString();
    }
}
