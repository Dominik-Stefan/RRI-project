using UnityEngine;

public class ShootingTypes : MonoBehaviour
{
    public float angle = 10;
    public float force = 10;
    public float bulletTimeToDeath = 5;
    public GameObject bullet;
    public Transform bulletTransform;

    public void Start()
    {

    }

    public void SingleShoot(Vector2 direction)
    {
        //GameObject copy = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        GameObject bulletCopy = BulletObjectPool.SharedInstance.getPooledBulletObject();
        if(bulletCopy != null){
            bulletCopy.transform.position = bulletTransform.position;
            bulletCopy.transform.rotation = Quaternion.identity;
            bulletCopy.SetActive(true);
        }

        bulletCopy.GetComponent<Rigidbody2D>().velocity = (transform.rotation * direction).normalized * force;
        //Destroy(copy, bulletTimeToDeath);
    }

    public void SingleShoot()
    {
        //GameObject copy = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        GameObject bulletCopy = BulletObjectPool.SharedInstance.getPooledBulletObject();
        if(bulletCopy != null){
            bulletCopy.transform.position = bulletTransform.position;
            bulletCopy.transform.rotation = Quaternion.identity;
            bulletCopy.SetActive(true);
        }

        bulletCopy.GetComponent<Rigidbody2D>().velocity = (transform.rotation * Vector2.right).normalized * force;
        //Destroy(copy, bulletTimeToDeath);
    }

    public void DoubleShoot()
    {
        SingleShoot();
        Invoke("SingleShoot", 0.05f);
    }

    public void SpreadShoot(int bulletNumber = 2)
    {
        //if (bulletNumber % 2 == 0) bulletNumber = 3;

        float angleForBullet = 90 - angle * (bulletNumber - 1) / 2;

        for (int i = 0; i < bulletNumber; i++)
        {
            float directionX = bulletTransform.position.x + Mathf.Sin(angleForBullet * Mathf.PI / 180);
            float directionY = bulletTransform.position.y + Mathf.Cos(angleForBullet * Mathf.PI / 180);
            Vector2 direction = new Vector2(directionX, directionY);

            angleForBullet += angle;
            
            SingleShoot(direction - new Vector2(bulletTransform.position.x, bulletTransform.position.y));
        }
    }
}
