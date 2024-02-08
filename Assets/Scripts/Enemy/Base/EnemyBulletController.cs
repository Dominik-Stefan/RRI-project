using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public int bulletDamage = 100;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);

            collison.gameObject.GetComponent<PlayerController>().playerHealth -= bulletDamage;
            if (collison.gameObject.GetComponent<PlayerController>().playerHealth <= 0){
                collison.gameObject.GetComponent<PlayerController>().playerHealth = 0;
                GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
                gameController.gameOver = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("DistanceCheck")){
            gameObject.SetActive(false);
        }
    }
}
