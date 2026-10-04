using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100.0f;
    public float iFrames = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
