using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);

            collison.gameObject.GetComponent<EnemyController>().TakeDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("DistanceCheck")){
            gameObject.SetActive(false);
        }
    }
}
