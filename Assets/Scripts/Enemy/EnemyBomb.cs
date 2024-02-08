using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : EnemyController
{
    public GameObject explosion;
    public bool getXp = true;

    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        timer += Time.deltaTime;
    }

    public override void Death(){
        this.enemyHealth = this.enemyMaxHealth;
        gameObject.SetActive(false);
        Instantiate(explosion, transform.position, transform.rotation);

        if(getXp){
            Instantiate(gem, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            getXp = false;
            Death();
        }
    }
}
