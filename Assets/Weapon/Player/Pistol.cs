using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int damage = 10; 
    [SerializeField] private float speed = 10f; 

    [SerializeField] private float fireRate = 8f;

    private float timer;

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
    }

    public override void Execute()
    {
        if (timer > 0f)
        {
            return;
        }

        GameObject bulletObject =Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );
            Bullet bullet = bulletObject.GetComponent<Bullet>();

    if (bullet != null)
    {
        bullet.damage = damage;
        bullet.speed = speed;

    }

        timer = 1f / fireRate;
    }
}