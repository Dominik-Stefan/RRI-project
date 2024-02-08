using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyController
{
    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        timer += Time.deltaTime;
    }
}
