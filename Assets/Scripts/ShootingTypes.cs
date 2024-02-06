using UnityEngine;

public class ShootingTypes : MonoBehaviour
{
    public float angle = 80;
    public float force = 10;
    public GameObject bullet;
    public Transform bulletTransform;
    private ShootingController shootingController;

    public void Start()
    {
        shootingController = GetComponent<ShootingController>();
    }

    public void SingleShoot()
    {
        GameObject copy = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        //Debug.Log(transform.rotation);
        copy.GetComponent<Rigidbody2D>().velocity = (transform.rotation * Vector2.right).normalized * force;
        Destroy(copy, 5);
    }

    public void DoubleShoot()
    {
        SingleShoot();
        Invoke("SingleShoot", 0.05f);
    }

    public void SpreadShoot()
    {
        SingleShoot();

        GameObject copy2 = Instantiate(bullet, bulletTransform.position, Quaternion.identity);

        float directionX = bulletTransform.position.x + Mathf.Sin(angle * Mathf.PI / 180);
        float directionY = bulletTransform.position.y + Mathf.Cos(angle * Mathf.PI / 180);
        Vector3 direction = new Vector3(directionX, directionY, 0);

        copy2.GetComponent<Rigidbody2D>().velocity = (transform.rotation * (direction - bulletTransform.position)).normalized * force;
        Destroy(copy2, 5);

        GameObject copy3 = Instantiate(bullet, bulletTransform.position, Quaternion.identity);

        directionX = bulletTransform.position.x + Mathf.Sin((angle + 20) * Mathf.PI / 180);
        directionY = bulletTransform.position.y + Mathf.Cos((angle + 20) * Mathf.PI / 180);
        direction = new Vector3(directionX, directionY, 0);
        
        copy3.GetComponent<Rigidbody2D>().velocity = (transform.rotation * (direction - bulletTransform.position)).normalized * force;
        Destroy(copy3, 5);
    }
}
