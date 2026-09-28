using UnityEngine;

public class Graze : MonoBehaviour
{
    SpriteRenderer sr;
    float cool=0f;
    [SerializeField] public int Currentgraze =0;
    [SerializeField] private int Maxgraze = 100;
    [SerializeField] public Damageable damageable;

    public int CurrentGraze => Currentgraze;
    public int MaxGraze => Maxgraze;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        cool -= Time.deltaTime*2; 
        cool = Mathf.Clamp01(cool); 
        sr.color = new Color(1f, 1f, 1f, cool);

    }
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("EBullet"))
    {
        EBullet bullet = other.GetComponent<EBullet>();

        if (bullet != null && !bullet.grazed && damageable.hitting == false)
        {
            bullet.grazed = true;
            // グレイズ処理
        GameData.Grazes += 1;

            cool =1f;
        if (Currentgraze < Maxgraze)
        {
            Currentgraze += 1;
        }
            sr.color = new Color(1f, 1f, 1f, cool);

        }
    }
}
}
