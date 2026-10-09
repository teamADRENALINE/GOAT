using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Ready ready;
    [SerializeField] public GameOver gameover;

    public float moveSpeed = 5f;
    public bool locked = false;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = true;
    }

    void Update()
    {
        moveInput = Vector2.zero;
        if(ready.start == true && gameover.locked == false){

        if (Input.GetKey(KeyCode.W))
            moveInput.y += 1;

        if (Input.GetKey(KeyCode.S))
            moveInput.y -= 1;

        if (Input.GetKey(KeyCode.A)){
        spriteRenderer.flipX = false;
            moveInput.x -= 1;
        }
        if (Input.GetKey(KeyCode.D)){
        spriteRenderer.flipX = true;
            moveInput.x += 1;
        }
        }
        moveInput = moveInput.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}