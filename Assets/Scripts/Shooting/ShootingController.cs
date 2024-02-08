using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public ShootingTypes shootingTypes;
    public static float timeBetweenFiring;
    public static int currentAmmo;
    public static int ammo;
    public static float reloadTime;
    public static int pellets;
    public static float spreadAngle;
    public static int quickShoot;
    private bool canFire;
    private float timerForReload;
    private float timerForShooting;
    private Vector3 localMousePosition;
    private GameController gameController;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        canFire = true;
        switch (Gun.selectedGun)
        {
            case "Pistol":
                ammo = 6;
                timeBetweenFiring = 0.5f;
                reloadTime = 2f;
                quickShoot = 1;
                playerController.playerDamage = 20;
                break;
            case "Shotgun":
                ammo = 2;
                timeBetweenFiring = 0.5f;
                reloadTime = 3f;
                pellets = 4;
                spreadAngle = 1f;
                playerController.playerDamage = 10;
                break;
            case "Minigun":
                ammo = 50;
                timeBetweenFiring = 0.2f;
                reloadTime = 5f;
                spreadAngle = 0.01f;
                playerController.playerDamage = 5;
                break;
        }

        ShootingTypes.force = 20;
        currentAmmo = ammo;
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
                timerForShooting += Time.deltaTime;

                if (currentAmmo > 0)
                {
                    if (timerForShooting >= timeBetweenFiring)
                    {
                        timerForShooting = 0;
                        canFire = true;
                    }
                }
                else
                {
                    timerForReload += Time.deltaTime;
                    if (timerForReload >= reloadTime)
                    {
                        timerForReload = 0;
                        currentAmmo = ammo;
                    }
                }

            }

            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && canFire)
            {
                canFire = false;

                switch (Gun.selectedGun)
                {
                    case "Pistol":
                        if (quickShoot >= ammo)
                        {
                            quickShoot = ammo;
                        }

                        int bulletCount = quickShoot;

                        if (quickShoot >= currentAmmo)
                        {
                            bulletCount = currentAmmo;
                        }

                        shootingTypes.QuickShoot(bulletCount);
                        currentAmmo -= (bulletCount);
                        break;
                    case "Shotgun":
                        shootingTypes.SpreadShoot(pellets, spreadAngle);
                        currentAmmo--;
                        break;
                    case "Minigun":
                        shootingTypes.MinigunShoot(spreadAngle);
                        currentAmmo--;
                        break;
                }
            }
        }
    }
}
