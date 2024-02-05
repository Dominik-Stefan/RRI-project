using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    public int playerDamage = 10;
    public int exp = 0;
    public int expToLevelUp = 100;
    private Vector2 mov;
    private Rigidbody2D rb;
    private int level = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        }
    }

    public int GetLevel()
    {
        return level;
    }
}