using UnityEngine;
using UnityEngine.UI;

public class StartBack : MonoBehaviour
{
    public bool start = false;
    private RectTransform rect;
    [SerializeField] private float fadeSpeed = 1f;

    private Image image;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(5000f, 0f);
        image = GetComponent<Image>();

        Color color = image.color;
        color.a = 0f;
        image.color = color;
    }
    private void Update()
    {
        if(start == true){
        rect.anchoredPosition = new Vector2(0f, 0f);
        Color color = image.color;

        color.a = Mathf.MoveTowards(
            color.a,
            1f,
            fadeSpeed * Time.deltaTime
        );

        image.color = color;
        }
    }
}
