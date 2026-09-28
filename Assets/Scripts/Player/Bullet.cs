using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage;
    public bool grazed = false;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D other){
    Damageable damageable = other.GetComponent<Damageable>();
    if (other.CompareTag("Frame"))
{
    Destroy(gameObject);

}
    if (damageable != null && other.CompareTag("Boss"))
    {
        damageable.TakeDamage(damage);
        Destroy(gameObject);
    }
}
}