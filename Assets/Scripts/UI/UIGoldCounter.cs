using TMPro;
using UnityEngine;

public class UIGoldCounter : MonoBehaviour
{
    private int goldCounter;
    [SerializeField] TextMeshProUGUI goldCounterText;

    // Update is called once per frame
    void Update()
    {
        PlayerGoldDisplay();
    }

    private void PlayerGoldDisplay()
    {
        //goldCounterText.text = 
    }
}
