using TMPro;
using UnityEngine;

public class UIGoldCounter : MonoBehaviour
{
    static public int goldCounter;
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
