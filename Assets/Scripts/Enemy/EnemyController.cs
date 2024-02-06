using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float damegeTimer = 0.2f;
    public int enemyMaxHealth = 20;
    public int enemyDamage = 5;
    public int enemyExp = 10;
    private int enemyHealth;
    private GameObject player;
    private PlayerController playerController;
    private GameController gameController;
    private float timer;

    void Start()
    {
        this.enemyHealth = this.enemyMaxHealth;
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

    public void TakeDamage()
    {
        if (this.enemyHealth > 0)
        {
            this.enemyHealth -= playerController.playerDamage;
            Debug.Log("Hit: " + this.enemyHealth);
        }
        if (this.enemyHealth <= 0)
        {
            Destroy(gameObject);
            playerController.AddExpToPlayer(enemyExp);
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
            }
            if (playerController.playerHealth <= 0)
            {
                gameController.gameOver = true;
            }
        }
    }
}

