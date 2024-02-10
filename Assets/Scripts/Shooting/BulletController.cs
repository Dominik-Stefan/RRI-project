using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static int piercing;
    public int piercingCount;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Enemy"))
        {
            if (piercingCount <= 0)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
            collison.gameObject.GetComponent<EnemyController>().TakeDamage();
            piercingCount--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DistanceCheck"))
        {
            gameObject.SetActive(false);
        }
    }
}
