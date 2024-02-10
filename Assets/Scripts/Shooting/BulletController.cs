using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static int penetration;
    public int penetrationCount;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Enemy"))
        {
            if (penetrationCount <= 0)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
            collison.gameObject.GetComponent<EnemyController>().TakeDamage();
            penetrationCount--;
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
