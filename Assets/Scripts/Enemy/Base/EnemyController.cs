using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string nameOfEnemy = "";
    public float moveSpeed = 5f;
    public float damageTimer = 0.2f;
    public int enemyMaxHealth = 20;
    public int enemyDamage = 5;
    public GameObject gem;
    protected int enemyHealth;
    protected GameObject player;
    protected PlayerController playerController;
    protected GameController gameController;
    protected float timer;

    protected SpriteRenderer spriteRenderer;

    void Start()
    {
        this.enemyHealth = this.enemyMaxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void FlipSprite()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;

        float projectionOnRight = Vector3.Dot(directionToPlayer, transform.right);

        if (projectionOnRight < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (projectionOnRight > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


    public void TakeDamage()
    {
        if (this.enemyHealth > 0)
        {
            this.enemyHealth -= playerController.playerDamage;
            if (playerController.playerHealth + (playerController.GetPlayerBaseDamage() * playerController.lifeSteal) <= playerController.playerMaxHealth)
            {
                playerController.playerHealth += (playerController.GetPlayerBaseDamage() * playerController.lifeSteal);
            }
        }
        if (this.enemyHealth <= 0)
        {
            //Destroy(gameObject);
            Death();
        }
    }

    public void TakeExplosionDamage()
    {
        if (this.enemyHealth > 0)
        {
            this.enemyHealth -= 200;
        }
        if (this.enemyHealth <= 0)
        {
            //Destroy(gameObject);
            Death();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerController.playerHealth > 0 && timer >= damageTimer)
            {
                playerController.playerHealth -= enemyDamage;
                timer = 0;
            }
            playerController.CheckLife();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DistanceCheck"))
        {
            OutsideOfBorder();
        }
    }

    public virtual void Death()
    {
        Instantiate(gem, transform.position, transform.rotation);
        this.enemyHealth = this.enemyMaxHealth;
        gameObject.SetActive(false);
    }

    public virtual void OutsideOfBorder()
    {
        gameObject.SetActive(false);
    }
}

