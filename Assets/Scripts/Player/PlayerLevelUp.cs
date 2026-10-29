using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerLevelUp : MonoBehaviour
{
    [SerializeField] private LevelUpMenu levelUpMenu;
    private PlayerStats ps;

    private bool menuIsOpen = false;

    [Header("Availible Upgrades")]
    [SerializeField] private LevelUpOptionsSO[] availableUpgrades;
    private LevelUpOptionsSO[] selectedUpgrades = new LevelUpOptionsSO[2];

    private void Awake()
    {
        levelUpMenu = FindFirstObjectByType<LevelUpMenu>();
        ps = FindFirstObjectByType<PlayerStats>();

        if (levelUpMenu == null)
        {
            Debug.LogError("PlayerLevelUp: Could not find LevelUpMenu in the scene!", this);
        }

        if (ps == null)
        {
            Debug.LogError("PlayerLevelUp: Could not find PlayerStats in the scene!", this);
        }
    }
    void Update()
    {
        if (ps == null || levelUpMenu == null)
            return;

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
        if (levelUpMenu == null || ps == null)
            return;

        if (availableUpgrades == null || availableUpgrades.Length < 2)
        {
            Debug.LogWarning("At least two upgrades must be assigned.", this);
            return;
        }

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
