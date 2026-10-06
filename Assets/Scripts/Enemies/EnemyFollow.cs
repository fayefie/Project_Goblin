using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    public EnemyStatsSO enemyStats;

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
        // move towards player
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemyStats.movementSpeed * Time.deltaTime);
    }
}
