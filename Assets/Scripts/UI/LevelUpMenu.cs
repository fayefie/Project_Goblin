using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public TMP_Text newPlayerLevel;
    public TMP_Text upgradeOneName;
    public TMP_Text upgradeOneDescription;
    public TMP_Text upgradeTwoName;
    public TMP_Text upgradeTwoDescription;

    [SerializeField] private GameObject menuPanel;

    private PlayerLevelUp playerLevelUp;
    private PlayerStats ps;

    private void Awake()
    {
        ps = FindFirstObjectByType<PlayerStats>();
        playerLevelUp = FindFirstObjectByType<PlayerLevelUp>();

        HideMenu();
    }

    void Update()
    {
        if (ps != null && newPlayerLevel != null)
        {
            newPlayerLevel.text = "Levelled up to level " + ps.playerLevel + "!";
        }
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetUpgrades(LevelUpOptionsSO upgradeOne, LevelUpOptionsSO upgradeTwo)
    {
        upgradeOneName.text = upgradeOne.upgradeName;
        upgradeOneDescription.text = upgradeOne.upgradeDescription;

        upgradeTwoName.text = upgradeTwo.upgradeName;
        upgradeTwoDescription.text = upgradeTwo.upgradeDescription;
    }

    public void SelectUpgradeOne()
    {
        playerLevelUp.SelectUpgrade(0);
    }

    public void SelectUpgradeTwo()
    {
        playerLevelUp.SelectUpgrade(1);
    }
}
