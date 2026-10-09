using UnityEngine;

public class EBullet : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 1;
    public bool grazed = false;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.right * speed * -1;
    }

    public void UpdateSpeed()
    {
        rb.linearVelocity = transform.right * speed * -1;
    }

    public void SetRandomSpeedAndAngle(
        float minSpeed,
        float maxSpeed,
        float minAngle,
        float maxAngle)
    {
        speed = Random.Range(minSpeed, maxSpeed);

        float angle = Random.Range(minAngle, maxAngle);

        transform.Rotate(0f, 0f, angle);

        rb.linearVelocity = transform.right * speed * -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (other.CompareTag("Frame"))
        {
            Destroy(gameObject);
        }

        if (damageable != null &&
            other.CompareTag("Player") &&
            damageable.hitting == false)
        {
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}