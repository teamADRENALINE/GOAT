using UnityEngine;
using UnityEngine.UI;

public class EndBack : MonoBehaviour
{
    public bool end = false;

    private RectTransform rect;

    [SerializeField] private float fadeSpeed = 1f;

    private Image image;

    void Start()
    {
        rect = GetComponent<RectTransform>();

        //rect.anchoredPosition = new Vector2(5000f, 0f);

        image = GetComponent<Image>();
        // 最初は完全に表示
        Color color = image.color;
        color.a = 1f;
        image.color = color;
        end = true;
    }

    private void Update()
    {
        if (end == true)
        {
            // 中央へ移動
            rect.anchoredPosition = new Vector2(0f, 0f);

            // 不透明 → 透明
            Color color = image.color;

            color.a = Mathf.MoveTowards(
                color.a,
                0f,
                fadeSpeed * Time.deltaTime
            );

            image.color = color;
            if (color.a <= 0f)
                {
                    end = false;
                    rect.anchoredPosition = new Vector2(5000f, 0f);

                }       
        }
    }
}