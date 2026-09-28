using UnityEngine;

public class BulletAc : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float maxSpeed = 30f;

    private EBullet bullet;

    private void Awake()
    {
        bullet = GetComponent<EBullet>();
    }

    private void Update()
    {
        if (bullet == null)
            return;

        bullet.speed *= 1f + acceleration * Time.deltaTime;
        bullet.speed = Mathf.Min(bullet.speed, maxSpeed);

        bullet.UpdateSpeed();
    }
}