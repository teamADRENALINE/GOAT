using UnityEngine;
using System.Collections;

public class SetBeam : Weapon
{
    [SerializeField] private GameObject beamPrefab;

    [SerializeField] private float minSpeed = 3f;
    [SerializeField] private float maxSpeed = 8f;

    private Vector2 moveDirection;
    private Vector2 playerPosition;
    private float speed;

    public void SetPlayer(Transform target)
    {
        // Aが生成された瞬間のPlayerの座標を保存
        playerPosition = target.position;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;

        speed = Random.Range(minSpeed, maxSpeed);
    }

    public override void Execute()
    {
        StartCoroutine(beams());
    }

    private IEnumerator beams()
    {
        float timer = 0f;

        // 1秒間ランダム方向へ移動
        while (timer < 1f)
        {
            transform.position +=
                (Vector3)(moveDirection * speed * Time.deltaTime);

            timer += Time.deltaTime;

            yield return null;
        }

        // 最初に記憶したPlayer座標への方向を計算
        Vector2 playerDirection =
            (playerPosition - (Vector2)transform.position).normalized;

        // その方向を向く
        transform.right = playerDirection;

        // Beamを生成
        Instantiate(
            beamPrefab,
            transform.position,
            transform.rotation
        );

        // SetBeam自身を消す
        Destroy(gameObject);
    }
}