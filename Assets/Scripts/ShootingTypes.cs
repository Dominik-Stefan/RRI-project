using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingTypes : MonoBehaviour
{
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

        GameObject copy = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        Quaternion newRotation = transform.rotation;
        newRotation.z += 10 * Mathf.Deg2Rad;
        //Debug.Log(newRotation.z);
        copy.GetComponent<Rigidbody2D>().velocity = (newRotation * Vector2.right).normalized * force;
        Destroy(copy, 5);

        GameObject copy2 = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        Quaternion newRotation2 = transform.rotation;
        newRotation2.z -= 10 * Mathf.Deg2Rad;
        //Debug.Log(newRotation2.z);
        copy2.GetComponent<Rigidbody2D>().velocity = (newRotation2 * Vector2.right).normalized * force;
        Destroy(copy2, 5);
    }
}
