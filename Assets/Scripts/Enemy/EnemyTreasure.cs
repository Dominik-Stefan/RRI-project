using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTreasure : EnemyController
{
    private bool alerted = false;

    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!alerted && enemyHealth < enemyMaxHealth)
        {
            alerted = true;
            animator.SetBool("Alerted", true);
        }

        if (alerted)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step * -1);
            timer += Time.deltaTime;
        }

        FlipSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyRunCheck"))
        {
            alerted = true;
            animator.SetBool("Alerted", true);
        }
    }

    public override void OutsideOfBorder()
    {
        Destroy(gameObject);
    }

    public override void Death()
    {
        Instantiate(gem, transform.position, transform.rotation);
        //this.enemyHealth = this.enemyMaxHealth;
        Destroy(gameObject);
    }
}
