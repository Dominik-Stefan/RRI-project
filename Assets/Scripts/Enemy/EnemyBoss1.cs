using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : EnemyController
{
    //Follow 1, stand 2, flee 3
    private int follow = 1;
    private Vector2 newPosition;
    public int shootingInterval = 180;
    public int shootingForce = 10;
    private int counter = 0;
    private bool canShoot = false;
    public int level = 2;
    public float spreadAngle = 1f;
    public int bulletCount = 4;

    //1 - pistol, 2 - shotgun
    void Update()
    {
        switch (follow)
        {
            case 1:
                Move(1);
                break;
            case 2:
                break;
            case 3:
                Move(-1);
                break;
        }

        counter += 1;
        if (counter >= shootingInterval && canShoot && GameController.paused == false && !gameController.levelUp && !gameController.gameOver)
        {
            counter = 0;

            if (level == 1)
            {
                SingleShoot();
            }
            else if (level == 2)
            {
                DoubleShoot();
                Invoke("DoubleShoot", 0.7f);
            }
        }

        FlipSprite();
    }

    private void DoubleShoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float spreadDirection = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
            Vector2 randomOffset = Random.insideUnitCircle * spreadDirection;
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized * shootingForce + randomOffset;
            SingleShoot(direction * shootingForce);
        }
        PlayShoot();
    }

    private void SingleShoot()
    {
        GameObject bulletCopy = EnemyBulletObjectPool.SharedInstance.getPooledEnemyBulletObject();
        if (bulletCopy != null)
        {
            bulletCopy.transform.position = transform.position;
            bulletCopy.transform.rotation = transform.rotation;
            bulletCopy.SetActive(true);

            Vector2 moveDirection = (player.transform.position - transform.position).normalized * shootingForce;
            bulletCopy.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        PlayShoot();
    }

    private void SingleShoot(Vector2 direction)
    {
        GameObject bulletCopy = EnemyBulletObjectPool.SharedInstance.getPooledEnemyBulletObject();
        if (bulletCopy != null)
        {
            bulletCopy.transform.position = transform.position;
            bulletCopy.transform.rotation = Quaternion.identity;
            bulletCopy.SetActive(true);

            bulletCopy.GetComponent<Rigidbody2D>().velocity = (transform.rotation * direction).normalized * shootingForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyStandCheck"))
        {
            follow = 2;
        }
        if (collision.gameObject.CompareTag("EnemyRunCheck"))
        {
            follow = 3;
        }
        if (collision.gameObject.CompareTag("EnemyShootCheck"))
        {
            canShoot = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyStandCheck"))
        {
            follow = 1;
        }
        if (collision.gameObject.CompareTag("EnemyRunCheck"))
        {
            follow = 2;
        }
        if (collision.gameObject.CompareTag("EnemyShootCheck"))
        {
            canShoot = false;
        }
        if (collision.gameObject.CompareTag("DistanceCheck"))
        {
            OutsideOfBorder();
        }
    }

    private void Move(int direction)
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step * direction);
        timer += Time.deltaTime;
    }

    public override void OutsideOfBorder()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x - 5, player.transform.position.y - 5);
    }
}
