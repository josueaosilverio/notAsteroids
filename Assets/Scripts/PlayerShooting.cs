using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField]
    private Transform shotOrigin;

    AudioSource shootSound;


    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed = 20f;



    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        shootSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, shotOrigin.position, shotOrigin.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(shotOrigin.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
