using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using Upgrades;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    public int playerDamage = 10;
    public int exp = 0;
    public int expToLevelUp = 100;
    public int lifeSteal = 0;
    private GameController gameController;
    private Vector2 mov;
    private Rigidbody2D rb;
    private int level = 1;
    private int playerBaseHealth;
    private float baseMoveSpeed;
    private Animator animator;
    private bool check = false;
    //private SpriteRenderer spr;

    private AudioSource audioSo;
    public AudioClip PlayerHurt;
    public AudioClip PlayerDeath;
    public AudioClip PlayerDeath2;
    private bool canPlaySound = true;

    void Start()
    {
        playerBaseHealth = playerHealth;
        baseMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = GetComponent<Animator>();
        audioSo = GetComponent<AudioSource>();
        //spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");


        /*if(mov.y > 0){
            animator.SetBool("LookingDown", false);
        }else if(mov.y < 0){
            animator.SetBool("LookingDown", true);
        }
        
        if(mov.x > 0){
            spr.flipX = false;
        }else if(mov.x < 0){
            spr.flipX = true;
        }*/

        if (mov.x != 0 || mov.y != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void FixedUpdate()
    {
        mov = mov.normalized * Time.fixedDeltaTime * moveSpeed;
        rb.MovePosition(rb.position + mov);
    }

    IEnumerator CanPlay(){
        yield return new WaitForSeconds(0.5f);
        canPlaySound = true;
    }

    IEnumerator DeathSound(){
        yield return new WaitForSeconds(1.7f);
        audioSo.PlayOneShot(PlayerDeath2);
    }

    public void CheckLife()
    {   
        if(canPlaySound == true){
            canPlaySound = false;
            StartCoroutine("CanPlay");
            audioSo.PlayOneShot(PlayerHurt);
        }
        if (playerHealth <= 0 && check == false)
        {
            check = true;
            playerHealth = 0;
            animator.SetBool("Dead", true);

            audioSo.Stop();
            audioSo.PlayOneShot(PlayerDeath);
            StartCoroutine("DeathSound");

            GameObject grid = GameObject.FindGameObjectWithTag("Grid");
            if (grid != null)
            {
                grid.SetActive(false);
            }
            GameObject rp = GameObject.FindGameObjectWithTag("RotatePoint");
            if (rp != null)
            {
                rp.SetActive(false);
            }
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in gos)
            {
                if (go.activeInHierarchy)
                {
                    go.SetActive(false);
                }
            }
            gos = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject go in gos)
            {
                if (go.activeInHierarchy)
                {
                    go.SetActive(false);
                }
            }
            gos = GameObject.FindGameObjectsWithTag("Gem");
            foreach (GameObject go in gos)
            {
                if (go.activeInHierarchy)
                {
                    go.SetActive(false);
                }
            }
            gos = GameObject.FindGameObjectsWithTag("Explosion");
            foreach (GameObject go in gos)
            {
                if (go.activeInHierarchy)
                {
                    go.SetActive(false);
                }
            }
            gameController.inGameHUD.rootVisualElement.style.display = DisplayStyle.None;


            Invoke("goToGameOver", 2.7f);
        }
    }

    public void goToGameOver()
    {
        gameController.gameOver = true;
    }

    public void AddExpToPlayer(int expGained)
    {
        exp += expGained;

        ExpChecker();
    }

    private void ExpChecker()
    {
        if (exp >= expToLevelUp)
        {
            level++;
            exp -= expToLevelUp;
            expToLevelUp = expToLevelUp + (int)(expToLevelUp * 0.1f);
            gameController.ShowLevelUpMenu();
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetPlayerBaseHealth()
    {
        return playerBaseHealth;
    }

    public float GetBaseMoveSpeed()
    {
        return baseMoveSpeed;
    }
}