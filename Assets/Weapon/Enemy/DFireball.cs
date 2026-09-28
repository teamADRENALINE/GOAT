using UnityEngine;

public class DFireball : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int damage = 10; 
    [SerializeField] private float speed = 2f; 

    public override void Execute()
    {
         GameObject bulletObject =Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation* Quaternion.Euler(0, 0, -90f)
        );
        EBullet bullet = bulletObject.GetComponent<EBullet>();

    if (bullet != null)
    {
        bullet.damage = damage;
        bullet.speed = speed;
    }
    
    }
}