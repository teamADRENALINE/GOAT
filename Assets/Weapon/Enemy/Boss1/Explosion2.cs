using UnityEngine;

public class Explosion2 : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;
    [SerializeField] private int damage = 10;

    private void Start()
    {
        // Eexplosionにダメージを渡す
        EExplosion explosion = GetComponent<EExplosion>();

        if (explosion != null)
        {
            explosion.damage = damage;
        }

        // 1秒後に消える
        Destroy(gameObject, lifeTime);
    }
}