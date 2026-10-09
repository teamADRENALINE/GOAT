using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;
    [SerializeField] private int damage = 10;

    private void Start()
    {
        // EBeamにダメージを渡す
        EBeam beam = GetComponent<EBeam>();

        if (beam != null)
        {
            beam.damage = damage;
        }

        // 1秒後に消える
        Destroy(gameObject, lifeTime);
    }
}