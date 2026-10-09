using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public StartBack startback;
    [SerializeField] public GOver go;

    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fadeSpeed = 1f;

    [SerializeField] private GameObject gameover;
    [SerializeField] private Damageable damageableboss;
    public bool locked = false;
    bool fade = false;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fade == true){
        Color color = sprite.color;

        if(color.a > 0f){

        color.a = Mathf.MoveTowards(
            color.a,
            0f,
            fadeSpeed * Time.deltaTime
        );

        sprite.color = color;
        }}
    }
    public void Over(){
        locked = true;
        fade = true;
        startback.start = true;
        go.start = true;
            Instantiate(
            explosion,
            firePoint.position,
            firePoint.rotation* Quaternion.Euler(0, 0, 0)
        );
        StartCoroutine(Change());
    }
    private IEnumerator Change(){
        yield return new WaitForSeconds(7f);
            SceneManager.LoadScene("BossSelect");
    }

}
