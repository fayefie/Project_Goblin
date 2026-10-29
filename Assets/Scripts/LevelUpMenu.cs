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

    private PlayerLevelUp playerLevelUp;

    private PlayerStats ps;

    private void Awake()
    {
        ps = FindFirstObjectByType<PlayerStats>();
        playerLevelUp = FindFirstObjectByType<PlayerLevelUp>();
        HideMenu();
    }

    void Start()
    {

    }

    void Update()
    {
        OnLevelUp();
    }

    public void ShowMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnLevelUp()
    {
        newPlayerLevel.text = ("Levelled up to level " + ps.playerLevel + "!");
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
