using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerLevelUp : MonoBehaviour
{
    private LevelUpMenu levelUpMenu;
    private PlayerStats ps;

    private bool menuIsOpen = false;

    [Header("Availible Upgrades")]
    [SerializeField] private LevelUpOptionsSO[] availableUpgrades;
    private LevelUpOptionsSO[] selectedUpgrades = new LevelUpOptionsSO[2];

    private void Awake()
    {
        levelUpMenu = FindFirstObjectByType<LevelUpMenu>();
        ps = FindFirstObjectByType<PlayerStats>();
    }
    void Update()
    {
        PlayerHasLevelledUp();
    }

    void PlayerHasLevelledUp()
    {
       if (ps.hasPlayerLevelledUp == true && menuIsOpen == false)
        {
            OpenLevelUpMenu();
        }
    }

    private void OpenLevelUpMenu()
    {
        if (availableUpgrades.Length < 2)
        {
            return;
        }

        menuIsOpen = true;
        levelUpMenu.ShowMenu();

        int firstIndex = Random.Range(0, availableUpgrades.Length);
        int secondIndex;

        do
        {
            secondIndex = Random.Range(0, availableUpgrades.Length);
        }
        while (secondIndex == firstIndex);

        selectedUpgrades[0] = availableUpgrades[firstIndex];
        selectedUpgrades[1] = availableUpgrades[secondIndex];

        // display choices in the menu
        levelUpMenu.SetUpgrades(selectedUpgrades[0], selectedUpgrades[1]);
    }

    public void SelectUpgrade(int index)
    {
        if (!menuIsOpen || index < 0 || index >= selectedUpgrades.Length)
        {
            return;
        }

        LevelUpOptionsSO chosenUpgrade = selectedUpgrades[index];

        if (chosenUpgrade == null)
        {
            return;
        }

        chosenUpgrade.Apply(gameObject);

        ps.health = ps.maxHealth;

        ps.hasPlayerLevelledUp = false;
        menuIsOpen = false;

        levelUpMenu.HideMenu();
    }
}
