using UnityEngine;
using System.Collections;

public class Boss1Action : MonoBehaviour
{
private float value = 0f;
private float maxValue = 100f;

[SerializeField] private Color startColor = Color.white;
[SerializeField] private Color targetColor = Color.red;
[SerializeField] private Killed killed;

private SpriteRenderer spriteRenderer;
private Phase phase;

private int count = 0;

void Start()
{
    phase = GetComponent<Phase>();
    spriteRenderer = GetComponent<SpriteRenderer>();
}

void Update()
{
    if (killed.death == true){ return;}

    float ratio = Mathf.Clamp01(value / maxValue);

    spriteRenderer.color = Color.Lerp(
        startColor,
        targetColor,
        ratio
    );

    if (phase.CurrentPhase == 2 && count == 0)
    {
        StartCoroutine(Red1());
        count += 1;
    }
    else if (phase.CurrentPhase == 3 && count == 1)
    {
        StartCoroutine(Red2());
        count += 1;
    }
}

private IEnumerator Red1()
{
    while (value < 50f)
    {
        value = Mathf.Min(value + 2f, 50f);
        yield return new WaitForSeconds(0.1f);
    }
}

private IEnumerator Red2()
{
    while (value < 100f)
    {
        value = Mathf.Min(value + 2f, 100f);
        yield return new WaitForSeconds(0.1f);
    }
}

}
