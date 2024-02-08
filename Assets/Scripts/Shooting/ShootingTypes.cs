using UnityEngine;

public class ShootingTypes : MonoBehaviour
{
    //public float angle = 10;
    //public float bulletTimeToDeath = 5;
    public static float force;
    public GameObject bullet;
    public Transform bulletTransform;

    public void Start()
    {

    }

    public void SingleShoot(Vector2 direction)
    {
        //GameObject copy = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        GameObject bulletCopy = BulletObjectPool.SharedInstance.getPooledBulletObject();
        if (bulletCopy != null)
        {
            bulletCopy.transform.position = bulletTransform.position;
            bulletCopy.transform.rotation = Quaternion.identity;
            bulletCopy.SetActive(true);

            bulletCopy.GetComponent<Rigidbody2D>().velocity = (transform.rotation * direction).normalized * force;
        }
        //Destroy(copy, bulletTimeToDeath);
    }

    public void SingleShoot()
    {
        //GameObject copy = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        GameObject bulletCopy = BulletObjectPool.SharedInstance.getPooledBulletObject();
        if (bulletCopy != null)
        {
            bulletCopy.transform.position = bulletTransform.position;
            bulletCopy.transform.rotation = Quaternion.identity;
            bulletCopy.SetActive(true);

            bulletCopy.GetComponent<Rigidbody2D>().velocity = (transform.rotation * Vector2.right).normalized * force;
        }
        //Destroy(copy, bulletTimeToDeath);
    }

    public void DoubleShoot(bool doubleShoot = false)
    {
        SingleShoot();
        if (doubleShoot)
        {
            Invoke("SingleShoot", 0.05f);
        }
    }

    public void MinigunShoot(float spreadAngle = 0.01f)
    {
        GameObject bulletCopy = BulletObjectPool.SharedInstance.getPooledBulletObject();
        if (bulletCopy != null)
        {
            bulletCopy.transform.position = bulletTransform.position;
            bulletCopy.transform.rotation = Quaternion.identity;
            bulletCopy.SetActive(true);

            float randomOffsetX = Random.Range(-force * spreadAngle, force * spreadAngle);
            float randomOffsetY = Random.Range(-force * spreadAngle, force * spreadAngle);

            Vector2 randomDirection = new Vector2((transform.right.x + randomOffsetX), (transform.right.y + randomOffsetY)).normalized;
            bulletCopy.GetComponent<Rigidbody2D>().velocity = randomDirection * force;
        }
    }


    /* public void SpreadShoot(int bulletNumber = 2)
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
    } */

    /* public void SpreadShoot(int bulletNumber = 4, float spreadAngle = 10f)
    {
        Vector2[] directions = new Vector2[bulletNumber];

        for (int i = 0; i < bulletNumber; i++)
        {
            float spreadDirection = 10 - spreadAngle / 2 + spreadAngle * i / (bulletNumber - 1);
            directions[i] = Quaternion.Euler(0, 0, spreadDirection) * Vector2.right;
        }

        foreach (var direction in directions)
        {
            SingleShoot(direction * force);
        }
    } */

    public void SpreadShoot(int bulletNumber = 4, float spreadAngle = 1f)
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            float spreadDirection = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);

            Vector2 randomOffset = Random.insideUnitCircle * spreadDirection;

            Vector2 direction = Vector2.right + randomOffset;

            direction = direction.normalized;

            SingleShoot(direction * force);
        }
    }
}
