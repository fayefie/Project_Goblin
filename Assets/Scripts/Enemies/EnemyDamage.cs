using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] private float damageDealt = 7.0f;
    [SerializeField] private float timeBeforeDamage;
    [SerializeField] private float damageGracePeriod;
    private bool canDealDamage = true;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeBeforeDamage = playerStats.iFrames;
        damageGracePeriod = timeBeforeDamage;
    }

    private void Awake()
    {
        PolygonCollider2D polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIFrames();
    }

    private void PlayerIFrames()
    {
        if (canDealDamage == false)
        {
            damageGracePeriod -= Time.deltaTime;
            Debug.Log("can deal damage again in: " + damageGracePeriod); // REMOVE AFTER IMPLIMENTATION

            if (damageGracePeriod <= 0)
            {
                canDealDamage = true;
                damageGracePeriod = timeBeforeDamage;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDealDamage == true)
        {
            playerStats.TakeDamage(damageDealt);
            canDealDamage = false;
        }
    }
}
