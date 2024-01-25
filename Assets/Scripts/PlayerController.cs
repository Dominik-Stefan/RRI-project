using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;
    public float moveSpeed;
    public int health = 5;
    private Vector2 mov;
    private Rigidbody2D rb;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (health > 0)
            {
                health--;
            }
            if (health == 0)
            {
                gameController.gameOver = true;
            }
        }
    }
}
