using UnityEngine;
using System.Collections;

public class Circle : Pattern
{
    [SerializeField] private GameObject setbeam;
    [SerializeField] private Transform player;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float speed = 90f;

    private SpriteRenderer spriteRenderer;

    private bool moving = false;
    private float angle;

    public override void Execute()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 最初の位置をプレイヤーからradius離す
        transform.position =
            player.position + Vector3.right * radius;

        // 角度を0度にする
        angle = 0f;

        moving = true;

        StartCoroutine(beam());
        StartCoroutine(cir());
    }

    private IEnumerator cir()
    {
        Boss1 boss = GetComponent<Boss1>();

        yield return new WaitForSeconds(0.4f);

        while (moving == true)
        {
            // 角度を進める
            angle += speed * Time.deltaTime;

            // 円周上の位置を計算
            float x =
                Mathf.Cos(angle * Mathf.Deg2Rad) * radius;

            float y =
                Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

            // プレイヤーを中心に配置
            transform.position = new Vector3(
                player.position.x + x,
                player.position.y + y,
                transform.position.z
            );

            // 左右反転
            if (transform.position.x < player.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            yield return null;
        }

        //spriteRenderer.flipX = false;
        //moving = false;
    }

    private IEnumerator beam()
    {
        for (int i = 1; i < 7; i++)
        {
            // 1秒待つ
            yield return new WaitForSeconds(1f);

            // SetBeamを生成
            GameObject newSetBeam = Instantiate(
                setbeam,
                transform.position,
                Quaternion.identity
            );

SetBeam setBeamScript =
    newSetBeam.GetComponent<SetBeam>();

setBeamScript.SetPlayer(player);

Vector2 randomDirection =
    Random.insideUnitCircle.normalized;

setBeamScript.SetMoveDirection(randomDirection);

setBeamScript.Execute();
        }

        // 最後のSetBeam生成後、2秒待つ
        yield return new WaitForSeconds(1f);
        Boss1 boss = GetComponent<Boss1>();

        spriteRenderer.flipX = false;
        moving = false;
        boss.finish = true;
    }
}