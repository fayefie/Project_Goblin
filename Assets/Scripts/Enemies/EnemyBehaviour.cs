using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    private Transform target;
    private PlayerStats playerStats;
    [SerializeField] private Animator animator;
    public EnemyStatsSO enemyStats;
    public float baseEnemyDamageFrames = 1.0f;
    public float currentEnemyDamageFrames;
    private bool isEnemyDamaged = false;
    static public int enemyKillCounter;
    public GameObject droppedXP;
    Transform xpParentEmpty;
    public float despawnDistance = 20f;
    private bool isDead = false;


    // current stats
    public float currentMoveSpeed;
    public float currentHealth;
    public float currentDamage;

    private void Awake()
    {
        PolygonCollider2D polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;

        target = FindFirstObjectByType<PlayerStats>().transform;
        playerStats = FindFirstObjectByType<PlayerStats>();
        xpParentEmpty = GameObject.Find("XP Orbs").transform;

        currentMoveSpeed = enemyStats.movementSpeed;
        currentHealth = enemyStats.enemyHealth;
        currentDamage = enemyStats.enemyDamage;
        currentEnemyDamageFrames = baseEnemyDamageFrames;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // find player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        currentHealth = enemyStats.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEnemyAnimations();
        enemyFacesPlayer();

        if (isEnemyDamaged == true)
        {
            currentEnemyDamageFrames -= Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, target.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    public void TakeDamage(float dmg)
    {
        if (isDead) return;

        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (isDead) return;
        isDead = true;

        GameObject DroppedXpOrb = Instantiate(droppedXP, transform.position, Quaternion.identity);
        DroppedXpOrb.transform.SetParent(xpParentEmpty);
        enemyKillCounter++;

        EnemySpawner es = FindFirstObjectByType<EnemySpawner>();

        if (es != null)
        {
            es.OnEnemyKilled();
        }

        Destroy(gameObject);
    }

    private void MoveTowardsPlayer()
    {
        // enemy walks towards the player
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemyStats.movementSpeed * Time.deltaTime);
    }

    private void HandleEnemyAnimations()
    {
        // handle idle to run animation
        if (enemyStats.movementSpeed > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // switch to idle if player dies
        if (playerStats.health <= 0)
        {
            animator.SetBool("isRunning", false);
        }

        // attack animation
        if (playerStats.canBeDamaged == false)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        // exit damage animation
        if (currentEnemyDamageFrames <= 0)
        {
            animator.SetBool("isDamaged", false);
            isEnemyDamaged = false;
            currentEnemyDamageFrames = baseEnemyDamageFrames;
        }
    }

    private void enemyFacesPlayer()
    {
        Vector3 scale = transform.localScale;

        if (target.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }

        transform.localScale = scale;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerStats.canBeDamaged == true)
        {
            playerStats.TakeDamage(enemyStats.enemyDamage);
            playerStats.canBeDamaged = false;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            animator.SetBool("isDamaged", true);
            isEnemyDamaged = true;
        }
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindFirstObjectByType<EnemySpawner>();
        transform.position = target.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}
