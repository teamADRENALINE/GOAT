using UnityEngine;

public class EBullet : MonoBehaviour
{

    public float speed = 1f;
    public int damage =1;
    public bool grazed = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed * -1;
    }

    public void UpdateSpeed()
    {
        rb.linearVelocity = transform.right * speed * -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (other.CompareTag("Frame"))
        {
            Destroy(gameObject);
        }

        if (damageable != null && other.CompareTag("Player") && damageable.hitting == false)
        {
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}