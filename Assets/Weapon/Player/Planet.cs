using UnityEngine; 
 
public class Planet : Weapon 
{ 
    [Header("弾")] 
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private GameObject planet;

    [SerializeField] private Transform firePoint; 
 
    [Header("攻撃")] 
    [SerializeField] private int damage = 10; 
    [SerializeField] private int mindamage = 10; 
    [SerializeField] private int maxdamage = 300; 

    [SerializeField] private float speed = 10f; 
    [SerializeField] private float minspeed = 10f; 
    [SerializeField] private float maxspeed = 30f; 
    [Header("チャージ")] 
    [SerializeField] private float maxChargeTime = 2f; 
    [SerializeField] private float minimumScale = 0.5f; 
 
    [Header("色")] 
    [SerializeField] private Color normalColor = Color.white; 
    [SerializeField] private Color redColor = Color.red; 
    [SerializeField] private Color blueColor = Color.blue; 
 
    private float chargeTime = 0f; 
    private bool charging = false; 
 
    private SpriteRenderer spriteRenderer; 
 
    private void Awake() 
    { 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        planet.SetActive(false);

    } 
 
    private void Update() 
    { 
        // チャージ中 
        if (charging) 
        { 
            chargeTime += Time.deltaTime; 

            // 0～1に変換 
            float charge = Mathf.Clamp01(chargeTime / maxChargeTime); 
            damage = (int)Mathf.Lerp(mindamage, maxdamage, charge); 
            speed = Mathf.Lerp(minspeed, maxspeed, charge); 


            // 大きさを1 → 0.5にする 
            float scale = Mathf.Lerp(1f, minimumScale, charge); 
 
            transform.localScale = Vector3.one * scale; 
 
            // 色を変化させる 
            if (charge < 0.5f) 
            { 
                float t = charge / 0.5f; 
                spriteRenderer.color = Color.Lerp(normalColor, redColor, t); 
            } 
            else 
            { 
                float t = (charge - 0.5f) / 0.5f; 
                spriteRenderer.color = Color.Lerp(redColor, blueColor, t); 
            } 
        } 
    } 
 
    public override void Execute() 
    { 
        // 初めて押した 
        if (!charging) 
        { 
            planet.SetActive(true);
            charging = true; 
            chargeTime = 0f; 
        } 
    } 
 
public void Release()
{
    if (!charging)
        return;

    charging = false;
    // 現在の大きさ・色をそのまま保存
    Vector3 currentScale = transform.localScale;
    Color currentColor = spriteRenderer.color;

    // 現在の状態でPrefabを発射
    GameObject bulletObject = Instantiate(
        bulletPrefab,
        firePoint.position,
        firePoint.rotation
    );

    // 発射したPrefabにも現在の状態を適用
    bulletObject.transform.localScale = currentScale;

    SpriteRenderer bulletSprite = bulletObject.GetComponent<SpriteRenderer>();

    if (bulletSprite != null)
    {
        bulletSprite.color = currentColor;
    }

    Bullet bullet = bulletObject.GetComponent<Bullet>();

    if (bullet != null)
    {
        bullet.damage = damage;
        bullet.speed = speed;

    }
    transform.localScale = Vector3.one;
    spriteRenderer.color = normalColor;
    damage = mindamage;
    speed = minspeed;

}
}