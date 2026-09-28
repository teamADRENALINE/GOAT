using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Killed : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject flash;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private SBTrigger sbtrigger;

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
    public void kill(){
        StartCoroutine(time());
    }
    private IEnumerator time(){

        yield return new WaitForSeconds(1f);
        flashed();
        yield return new WaitForSeconds(1f);
        flashed();
        yield return new WaitForSeconds(1f);
        flashed();
        explode();
        fade = true;
        sbtrigger.Trigger();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Result");
    }
    private void explode(){
        Instantiate(
            explosion,
            firePoint.position,
            firePoint.rotation* Quaternion.Euler(0, 0, 0)
        );
    }
    private void flashed(){
        Instantiate(
            flash,
            firePoint.position,
            firePoint.rotation* Quaternion.Euler(0, 0, 0)
        );
    }
}
