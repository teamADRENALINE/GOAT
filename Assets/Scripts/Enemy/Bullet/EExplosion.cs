using UnityEngine;
using System.Collections;

public class EExplosion : MonoBehaviour
{
    public int damage = 1;
    public bool grazed = false;
    bool grazelock = false;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void UpdateSpeed()
    {
        if(grazed == true && grazelock ==false){
            StartCoroutine(graze());
            grazelock = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable != null &&
            other.CompareTag("Player") &&
            damageable.hitting == false)
        {
            damageable.TakeDamage(damage);
        }
    }
    private IEnumerator graze(){
        yield return new WaitForSeconds(0.3f);
        grazed = false;
        grazelock = false;
    }
}