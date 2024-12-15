using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _rightBulletRoot;
    [SerializeField] private Transform _leftBulletRoot;
    [SerializeField] private AudioSource shootSource;

    [SerializeField] private PlayerMovement playerScript;

    [SerializeField] private Pause pause;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!pause.isGamePaused)
        {
            if (playerScript.IsGunLookingRight)
            {
                Instantiate(_bulletPrefab, _rightBulletRoot.position, _rightBulletRoot.transform.rotation);
                shootSource.panStereo = 1;
            }
            else
            {
                Instantiate(_bulletPrefab, _leftBulletRoot.position, _leftBulletRoot.transform.rotation);
                shootSource.panStereo = -1;
            }
        }
        shootSource.Play();
    }
}