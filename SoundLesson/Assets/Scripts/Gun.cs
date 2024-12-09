using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _rightBulletRoot;
    [SerializeField] private Transform _leftBulletRoot;
    [SerializeField] private KeyCode shootKeyCode;
    [SerializeField] private AudioSource shootSource;

    [SerializeField] private PlayerMovement playerScript;

    private void Update()
    {
        if (Input.GetKeyDown(shootKeyCode) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (playerScript.IsGunLookingRight)
        {
            Instantiate(_bulletPrefab, _rightBulletRoot.position, _rightBulletRoot.transform.rotation);
        }
        else
        {
            Instantiate(_bulletPrefab, _leftBulletRoot.position, _leftBulletRoot.transform.rotation);
        }
        shootSource.Play();
    }
}