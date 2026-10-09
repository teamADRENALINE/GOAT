using UnityEngine;

public class HFireball : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int damage = 10;

    [SerializeField] private float minSpeed = 8f;
    [SerializeField] private float maxSpeed = 12f;

    [SerializeField] private float minAngle = -15f;
    [SerializeField] private float maxAngle = 15f;
    
public override void Execute()
{
    GameObject bulletObject = Instantiate(
        bulletPrefab,
        firePoint.position,
        firePoint.rotation
    );

    EBullet bullet = bulletObject.GetComponent<EBullet>();

    bulletObject.transform.localScale = Vector3.one * 2f;

    bullet.SetRandomSpeedAndAngle(
        minSpeed,
        maxSpeed,
        minAngle,
        maxAngle
    );

    if (bullet != null)
    {
        bullet.damage = damage;
    }
}
}