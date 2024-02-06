using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public ShootingTypes shootingTypes;
    public float timeBetweenFiring;
    private bool canFire;
    private float timer;
    private Vector3 localMousePosition;
    private GameController gameController;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        canFire = true;
    }

    void Update()
    {
        if (GameController.paused == false && !gameController.levelUp && !gameController.gameOver)
        {
            localMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotationZ = Mathf.Atan2(localMousePosition.y, localMousePosition.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);

            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer >= timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButtonDown(0) && canFire)
            {
                canFire = false;

                if (playerController.GetLevel() < 2)
                {
                    shootingTypes.SingleShoot();
                }
                else if (playerController.GetLevel() < 3)
                {
                    shootingTypes.DoubleShoot();
                }
                else if (playerController.GetLevel() < 4)
                {
                    shootingTypes.SpreadShoot();
                }
                else
                {
                    shootingTypes.SpreadShoot(5);
                }
            }
        }
    }
}
