using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour
{
    SpriteRenderer sr;
    float cool = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        transform.position = new Vector3(
            0f,
            transform.position.y,
            transform.position.z
        );

        StartCoroutine(sign());
    }

    private IEnumerator sign()
    {
        cool = 0f;
        // 徐々に表示
        while (cool < 0.3f)
        {
            cool += Time.deltaTime*1.5f;
            cool = Mathf.Clamp01(cool);

            sr.color = new Color(1f, 1f, 1f, cool);

            yield return null;
        }

        // 0.5秒表示
        yield return new WaitForSeconds(0.5f);

        // 徐々に消える
        while (cool > 0f)
        {
            cool -= Time.deltaTime * 3f;
            cool = Mathf.Clamp01(cool);

            sr.color = new Color(1f, 1f, 1f, cool);

            yield return null;
        }

        Destroy(gameObject);
    }
}