using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class XPOrbBehaviour : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float movementSpeed = 5.0f;

    private void Awake()
    {
        target = FindFirstObjectByType<PlayerStats>().transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetXPOnCollide();
    }

    private void GetXPOnCollide()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= 1.0f)
        {
            PlayerStats.xp++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            Debug.Log("colliding");
        }
    }
}
