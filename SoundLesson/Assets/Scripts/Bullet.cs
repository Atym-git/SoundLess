using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D rb2D;

    [SerializeField] private SoundPlayer soundPlayer;

    private Pause pause;

    private void Start()
    {
       soundPlayer = FindFirstObjectByType<SoundPlayer>();
       Destroy(gameObject, 3);
       rb2D.AddForce(transform.up * _speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            soundPlayer.PlayClashSound();
            soundPlayer.AddDistortion();
        }
    }
}