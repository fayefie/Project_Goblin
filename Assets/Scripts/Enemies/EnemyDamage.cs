using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] private float damageDealt = 7.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        PolygonCollider2D polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerStats.canBeDamaged == true)
        {
            playerStats.TakeDamage(damageDealt);
            playerStats.canBeDamaged = false;
        }
    }
}
