using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int damage = 1;
    private PlayerHealth playerHealth;
    private Rigidbody2D enemyRb2D;
    [SerializeField] private float _aiMovementSpeed;
    private Pause pause;
    private void Start()
    {
        enemyRb2D = GetComponent<Rigidbody2D>();
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        pause = FindFirstObjectByType<Pause>();
        Direction();
    }

    private void Update()
    {
        AiMove();
    }

    private void AiMove()
    {
       if (!pause.isGamePaused)
       {
           enemyRb2D.velocity = new Vector2(_aiMovementSpeed, 0);
       }
       if (!playerHealth.isPlayerAlive)
       {
            Destroy(gameObject);
       }
    }

    private void Direction()
    {
        if ( gameObject.transform.position.x > 0)
        {
            _aiMovementSpeed *= -1;
        }
        else
        {
            _aiMovementSpeed *= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
