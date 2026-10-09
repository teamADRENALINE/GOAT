using UnityEngine;

public class SeedExpo : Weapon
{
    [SerializeField] private GameObject explosion2;
    [SerializeField] private int damage = 10;

    public override void Execute()
    {
        GameObject bulletObject = Instantiate(
            explosion2,
            transform.position,
            transform.rotation
        );

        EBullet bullet = bulletObject.GetComponent<EBullet>();

        if (bullet != null)
        {
            bullet.damage = damage;
        }

        Destroy(gameObject);
    }
}