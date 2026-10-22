using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Health Parameters")]
    public float health;
    public Image healthBar;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float baseIFrames = 1.0f;
    [SerializeField] private float damageGracePeriod;
    public bool canBeDamaged = true;

    [Header("XP Parameters")]
    public int xp;
    public Image xpBar;
    private int baseXp = 0;
    public int playerLevel;
    public int xpNeededToLevelUp;
    private int xpForFirstLevel = 5;

    public TopDownMovement topDownMovement;
    [SerializeField] private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        damageGracePeriod = baseIFrames;

        // xp and level up
        xp = baseXp;
        xpNeededToLevelUp = xpForFirstLevel;
        playerLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // health ui
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        // xp ui
        //xpBar.fillAmount += xp / xpNeededToLevelUp; FIX

        LevelUp();
        PlayerIFrames();
        HandleAnimations();
    }

    private void LevelUp()
    {

        // leveling curve
        if (playerLevel == 0)
        {
            xpNeededToLevelUp = xpForFirstLevel;
        }
        else if (playerLevel >= 1 && playerLevel <= 20)
        {
            xpNeededToLevelUp = xpForFirstLevel + (playerLevel * 10);
        }
        else if (playerLevel >= 20 && playerLevel <= 40)
        {
            xpNeededToLevelUp = xpForFirstLevel + (playerLevel * 13);
        }
        else if (playerLevel > 41)
        {
            xpNeededToLevelUp = xpForFirstLevel + (playerLevel * 16);
        }

        // level up
        if (xp >= xpNeededToLevelUp)
        {
            playerLevel++;
            xp = baseXp;
        }

        // debug
        if (Keyboard.current.kKey.wasReleasedThisFrame)
        {
            xp++;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayerIFrames()
    {
        if (canBeDamaged == false)
        {
            damageGracePeriod -= Time.deltaTime;

            if (damageGracePeriod <= 0)
            {
                canBeDamaged = true;
                damageGracePeriod = baseIFrames;
            }
        }
    }

    private void HandleAnimations()
    {
        // running
        if (topDownMovement.isPlayerMoving == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // taking damage
        if (damageGracePeriod < 1)
        {
            animator.SetBool("isTakingDamage", true);
        }
        else if (damageGracePeriod == 1)
        {
            animator.SetBool("isTakingDamage", false);
        }

        // dying
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }
}
