using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public int playerHealth = 100;
    public int playerDamage = 10;
    private Vector2 mov;
    private Rigidbody2D rb;
    private int level = 1;
    private int exp = 0;

    private int expToLevelUp = 100;

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

        Debug.Log("Exp: " + exp);

        ExpChecker();
    }

    private void ExpChecker()
    {
        if (exp >= expToLevelUp)
        {
            level++;
            exp -= expToLevelUp;
            expToLevelUp = expToLevelUp + (int)(expToLevelUp * 0.1f);
            Debug.Log("Level Up! ExpToLevelUp:" + expToLevelUp);
        }
    }
}