using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float baseIFrames = 1.0f;
    [SerializeField] private float damageGracePeriod;
    public bool canBeDamaged = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        damageGracePeriod = baseIFrames;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIFrames();
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

}
