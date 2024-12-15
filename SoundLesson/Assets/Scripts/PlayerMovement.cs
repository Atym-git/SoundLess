using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb2D;
    [SerializeField] private SpriteRenderer playerSr;
    [SerializeField] private float _movementSpeed;
    public bool IsGunLookingRight;

    [SerializeField] private Pause pause;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!pause.isGamePaused)
        {
            playerSr.enabled = true;
            float movement = Input.GetAxis("Horizontal");
            playerRb2D.velocity = new Vector2(movement * _movementSpeed, 0);
            FlipGun(movement);
        }
        else
        {
            playerSr.enabled = false;
        }
    }

    private void FlipGun(float movement)
    {
        if (movement != 0 && movement < 0)
        {
            IsGunLookingRight = false;
            playerSr.flipX = true;
        }
        else if (movement != 0 && movement > 0)
        {
            IsGunLookingRight = true;
            playerSr.flipX = false;
        }
    }
}