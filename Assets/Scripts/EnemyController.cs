using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float damegeTimer = 0.2f;
    public int enemyHealth = 20;
    public int enemyDamage = 5;
    public int enemyExp = 10;
    private GameObject player;
    private PlayerController playerController;
    private GameController gameController;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Bullet"))
        {
            if (enemyHealth > 0)
            {
                enemyHealth -= playerController.playerDamage;
                Destroy(collison.gameObject);
            }
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(collison.gameObject);
                playerController.AddExpToPlayer(enemyExp);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerController.playerHealth > 0 && timer >= damegeTimer)
            {
                playerController.playerHealth -= enemyDamage;
                timer = 0;
                Debug.Log("Health: " + playerController.playerHealth);
            }
            if (playerController.playerHealth <= 0)
            {
                gameController.gameOver = true;
            }
        }
    }
}

