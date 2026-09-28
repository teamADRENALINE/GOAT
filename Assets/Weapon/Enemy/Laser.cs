using UnityEngine;

public class Laser : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int damage = 10; 
    [SerializeField] private float speed = 10f; 

    public override void Execute()
    {
         GameObject bulletObject =Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );
        EBullet bullet = bulletObject.GetComponent<EBullet>();

    if (bullet != null)
    {
        bullet.damage = damage;
        bullet.speed = speed;

    }
    }
}