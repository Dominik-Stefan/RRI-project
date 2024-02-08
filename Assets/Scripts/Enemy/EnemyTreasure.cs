using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTreasure : EnemyController
{
    private bool alerted = false;

    private void Update(){
        if(!alerted && enemyHealth < enemyMaxHealth){
            alerted = true;
        }

        if(alerted){
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step * -1);
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("EnemyRunCheck")){
            alerted = true;
        }
    }

    public override void OutsideOfBorder(){
        gameObject.SetActive(false);
    }
}
