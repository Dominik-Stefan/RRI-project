using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    public int playerDamage = 10;
    public int exp = 0;
    public int expToLevelUp = 100;
    private GameController gameController;
    private Vector2 mov;
    private Rigidbody2D rb;
    private int level = 1;
    private int playerBaseHealth;
    private float baseMoveSpeed;
    private int playerBaseDamage;

    void Start()
    {
        playerBaseHealth = playerHealth;
        baseMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        mov = mov.normalized * Time.fixedDeltaTime * moveSpeed;
        rb.MovePosition(rb.position + mov);
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

    public float GetBaseMoveSpeed(){
        return baseMoveSpeed;
    }
    
    public int GetPlayerBaseDamage(){
        return playerBaseDamage;
    }
}