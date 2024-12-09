using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private SoundPlayer soundPlayer;

    private void Start()
    {
       soundPlayer = FindFirstObjectByType<SoundPlayer>();
       rb2D.AddForce(transform.up * _speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            soundPlayer.PlayClashSound();
        }
    }
}