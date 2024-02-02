using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float damegeTimer = 0.2f;
    public int health = 2;
    private GameObject player;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (health > 0)
            {
                health--;
                Destroy(collison.gameObject);
            }
            if (health == 0)
            {
                Destroy(gameObject);
                Destroy(collison.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.GetComponent<PlayerController>().health > 0 && timer >= damegeTimer)
            {
                player.GetComponent<PlayerController>().health--;
                timer = 0;
                Debug.Log("Health: " + player.GetComponent<PlayerController>().health);
            }
            if (player.GetComponent<PlayerController>().health == 0)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().gameOver = true;
            }
        }
    }
}

