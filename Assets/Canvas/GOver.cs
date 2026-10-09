using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GOver : MonoBehaviour
{
    public bool start = false;
    [SerializeField] public bool end = false;

    private RectTransform rect;
    private Image image;

    [SerializeField] private float fadeSpeed = 1f;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        rect.anchoredPosition = new Vector2(5000f, 0f);

        Color color = image.color;
        color.a = 0f;
        image.color = color;
    }

    private void Update()
    {
        // フェードアウト開始
        if (start == true && end == false)
        {
            rect.anchoredPosition = new Vector2(0f, 0f);

            Color color = image.color;

            color.a = Mathf.MoveTowards(
                color.a,
                1f,
                fadeSpeed * Time.deltaTime
            );

            image.color = color;

            // 完全に透明になったら終了
            if (color.a >= 1f)
            {
                start = false;
                end = true;

                StartCoroutine(End());
            }
        }
    }

    private IEnumerator End()
    {
        // 3秒待つ
        yield return new WaitForSeconds(5f);

        // フェードイン
        while (end == true)
        {
            Color color = image.color;

            color.a = Mathf.MoveTowards(
                color.a,
                0f,
                fadeSpeed * Time.deltaTime
            );

            image.color = color;

            // 完全に不透明になったら終了
            if (color.a <= 0f)
            {
                end = false;
                color.a = 0f;
                image.color = color;
                rect.anchoredPosition = new Vector2(5000f, 0f);
            }

            // 次のフレームまで待つ
            yield return null;
        }
    }
}