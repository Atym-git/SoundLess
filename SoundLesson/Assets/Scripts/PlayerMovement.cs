using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb2D;
    [SerializeField] private SpriteRenderer playerSr;
    [SerializeField] private float _movementSpeed;
    public bool IsGunLookingRight;

    private void Update()
    {
        Move();
        //Debug.Log(IsGunLookingRight);
    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        //Debug.Log(movement);
        playerRb2D.velocity = new Vector2(movement * _movementSpeed, 0);
        if (movement != 0 && movement < 0)
        {
            IsGunLookingRight = false;
            playerSr.flipX = true;
            //gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (movement != 0 && movement > 0)
        {
            IsGunLookingRight = true;
            playerSr.flipX = false;
        }
    }
}