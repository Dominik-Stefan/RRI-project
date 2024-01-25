using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;

    public int health = 2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
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
}

