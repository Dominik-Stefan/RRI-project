using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunman : EnemyController
{
    //Follow 1, stand 2, flee 3
    private int follow = 1;
    private Vector2 newPosition;
    public int shootingInterval = 180;
    public int shootingForce = 10;
    private int counter = 0;
    private bool canShoot = false;

    void Update(){
        switch(follow){
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
        if (counter >= shootingInterval && canShoot && GameController.paused == false && !gameController.levelUp && !gameController.gameOver){
            counter = 0;

            GameObject bulletCopy = EnemyBulletObjectPool.SharedInstance.getPooledEnemyBulletObject();
            if(bulletCopy != null){
                bulletCopy.transform.position = transform.position;
                bulletCopy.transform.rotation = transform.rotation;
                bulletCopy.SetActive(true);
            }

            Vector2 moveDirection = (player.transform.position - transform.position).normalized * shootingForce;
            bulletCopy.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("EnemyStandCheck")){
            follow = 2;
        }
        if(collision.gameObject.CompareTag("EnemyRunCheck")){
            follow = 3;
        }
        if(collision.gameObject.CompareTag("EnemyShootCheck")){
            canShoot = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("EnemyStandCheck")){
            follow = 1;
        }
        if(collision.gameObject.CompareTag("EnemyRunCheck")){
            follow = 2;
        }
        if(collision.gameObject.CompareTag("EnemyShootCheck")){
            canShoot = false;
        }
        if (collision.gameObject.CompareTag("DistanceCheck"))
        {
            OutsideOfBorder();
        }
    }

    private void Move(int direction){
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step * direction);
        timer += Time.deltaTime;    
    }
}
