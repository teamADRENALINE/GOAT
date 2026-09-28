using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1f;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.position = Vector3.zero;

    }

    private void Update()
    {
        Color color = sprite.color;

        color.a = Mathf.MoveTowards(
            color.a,
            0f,
            fadeSpeed * Time.deltaTime
        );

        sprite.color = color;

        if (color.a <= 0f)
        {
            Destroy(gameObject);
        }
    }
}