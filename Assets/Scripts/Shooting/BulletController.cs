using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collison.gameObject.GetComponent<EnemyController>().TakeDamage();
            collison.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
