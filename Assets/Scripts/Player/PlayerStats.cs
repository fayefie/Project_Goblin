using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Health Parameters")]
    public float health;
    public Image healthBar;
    public float xp;
    public Image xpBar;
    private float baseXp = 0;
    public int playerLevel;
    public float xpToLevelUp;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float baseIFrames = 1.0f;
    [SerializeField] private float damageGracePeriod;
    public bool canBeDamaged = true;
    public TopDownMovement topDownMovement;
    [SerializeField] private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        damageGracePeriod = baseIFrames;

        // xp and level up
        xp = baseXp;
        xpToLevelUp = 100;
        playerLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // health ui
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        // xp ui
        xpBar.fillAmount = Mathf.Clamp(xp / xpToLevelUp, 0, 1);

        PlayerIFrames();
        HandleAnimations();
    }

    //private float LevelUp()
    //{
    //    if (xp >= xpToLevelUp)
    //    {
    //        playerLevel++;
    //        xp = baseXp;
    //        //xpToLevelUp = xpToLevelUp * 0.5;
    //    }
    //}

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
