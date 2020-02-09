using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{


    Rigidbody2D rb;

    Vector3 mousePos;
    Vector3 playerPos;

    float rotateAngle;


    private Text healthText;
    private Text moneyText;
    private Text scoreText;

    private EnemySpawner spawner;

    private GameObject gameOverScreen;

    private ShipData shipData;


    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private int health = 3;


    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        healthText = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        moneyText = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
        gameOverScreen.SetActive(false);


        string healthString = "";
        for (int i = 0; i < health; i++)
        {
            healthString += "_";
        }
        healthText.text = healthString;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.velocity = new Vector2((Time.deltaTime * speed * Input.GetAxis("Horizontal")), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
        if (Input.GetAxis("Vertical") != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, (Time.deltaTime * speed * Input.GetAxis("Vertical")));
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

        }
        RotateToMouse();
    }


    void RotateToMouse()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -10;
        playerPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= playerPos.x;
        mousePos.y -= playerPos.y;
        rotateAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotateAngle - 90f));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            health--;
            string healthString = "";
            for (int i = 0; i < health; i++)
            {
                healthString += "_";
            }
            healthText.text = healthString;

            if (health == 0)
            {
                GameOver();
            }

        }
    }

    void GameOver()
    {
        spawner.spawning = false;

        gameOverScreen.SetActive(true);

        shipData = SaveManager.LoadPieces();

        SaveManager.SavePieces(shipData.unlockShips, shipData.money + int.Parse(scoreText.text), shipData.currentShip);

        moneyText.text = (int.Parse(scoreText.text)).ToString();

        Destroy(gameObject);

    }



}
