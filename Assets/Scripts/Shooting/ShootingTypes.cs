using UnityEngine;
using System.Collections;

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

            bulletCopy.GetComponent<BulletController>().penetrationCount = BulletController.penetration;

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

    public void QuickShoot(int bulletNumber)
    {
        StartCoroutine(ShootBullets(bulletNumber));
    }

    private IEnumerator ShootBullets(int bulletNumber)
    {
        SingleShoot();

        for (int i = 0; i < bulletNumber - 1; i++)
        {
            yield return new WaitForSeconds(0.05f);
            SingleShoot();
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
