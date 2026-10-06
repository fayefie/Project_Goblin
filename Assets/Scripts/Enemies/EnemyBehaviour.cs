using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Animator animator;
    public EnemyStatsSO enemyStats;

    private void Awake()
    {
        PolygonCollider2D polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // find player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        // enemy walks towards the player
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemyStats.movementSpeed * Time.deltaTime);

        // enemy faces player when moving
        //transform.LookAt(target);

        

        // handle idle to run animation
        if (enemyStats.movementSpeed > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerStats.canBeDamaged == true)
        {
            playerStats.TakeDamage(enemyStats.damageDealt);
            playerStats.canBeDamaged = false;
        }
    }
}
