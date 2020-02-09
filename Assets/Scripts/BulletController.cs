using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField]
    private GameObject hitParticle;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }



}
