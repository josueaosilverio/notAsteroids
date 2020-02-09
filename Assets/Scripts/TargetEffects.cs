using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TargetEffects : MonoBehaviour
{

    private CameraShake cameraShake;
    private AudioSource explosionSound;
    private AudioClip explosionClip;

    [SerializeField]
    private bool player = false;

    private void Start()
    {

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        explosionSound = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !player && !gameObject.CompareTag("Enemy"))
        {
            explosionClip = Resources.Load<AudioClip>("Sound/SFX/Explosion");
            explosionSound.clip = explosionClip;

            explosionSound.Play();
            StartCoroutine(cameraShake.Shake(.15f, .2f));
        }

        if (collision.gameObject.CompareTag("Enemy") && player)
        {
            explosionClip = Resources.Load<AudioClip>("Sound/SFX/Hurt");
            explosionSound.clip = explosionClip;

            StartCoroutine(cameraShake.Shake(.15f, .2f));
            explosionSound.Play();
        }

        if (collision.gameObject.CompareTag("Bullet") && gameObject.CompareTag("Enemy"))
        {
            explosionClip = Resources.Load<AudioClip>("Sound/SFX/EnemyHit");
            explosionSound.clip = explosionClip;

            StartCoroutine(cameraShake.Shake(.15f, .2f));
            explosionSound.Play();
        }


    }

}
