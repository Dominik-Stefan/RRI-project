using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{   
    private bool exploded = false;

    public void Start(){
        StartCoroutine(Cor());
        StartCoroutine(Fade());
    }

    IEnumerator Cor(){
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    IEnumerator Fade(){
        for(float f = 1f; f >= 0; f -= 0.01f){
            Color c= GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player") && !exploded)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.playerHealth -= 250;
            if (playerController.playerHealth <= 0)
            {
                GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
                playerController.playerHealth = 0;
                gameController.gameOver = true;
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeExplosionDamage();
        }
    }
}
