using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform target;

    [Header("Behaviour")]
    [SerializeField]
    private bool rotate = false;
    [SerializeField]
    private bool lookAtPlayer = false;
    [SerializeField]
    private bool follow = false;
    [SerializeField]
    private bool shoot = false;
    [SerializeField]
    private bool spaceInvader = false;



    [Header("Settings")]
    [SerializeField]
    public int scoreValue = 100;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float rotationSpeed = 50f;
    [SerializeField]
    private Transform shotOrigin;
    [SerializeField]
    private GameObject bulletPrefab;

    private bool spaceInvaderLR = false;


    private Text scoreText;


    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        if (shoot)
            InvokeRepeating("Shoot", 1f, 2f);
   
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
    

        if (rotate)
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        if (follow)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (lookAtPlayer)
        {
            float rotateAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotateAngle - 90f));
        }

        if (spaceInvader)
        {
            if (spaceInvaderLR)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0.1f, 0), speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(0.1f, 0), speed * Time.deltaTime);
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);

            int score = int.Parse(scoreText.text);

            score += scoreValue;

            scoreText.text = score.ToString();
        }

        if (spaceInvader)
        {
            spaceInvaderLR = !spaceInvaderLR;
            transform.position = transform.position - new Vector3(0, 0.2f, 0);
        }
    }




    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shotOrigin.position, shotOrigin.rotation);
    }
}
