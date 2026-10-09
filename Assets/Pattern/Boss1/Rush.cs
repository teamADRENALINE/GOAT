using UnityEngine;
using System.Collections;
public class Rush : Pattern
{
    [SerializeField] private Weapon ufireball;
    [SerializeField] private Weapon dfireball;
    [SerializeField] private GameObject sign;
    [SerializeField] private Transform firePoint;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform player;
    private float firerate=0f;
    float minfire = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Execute()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = true;

        StartCoroutine(Attack());
        }
    private IEnumerator Attack()
    {
    Boss1 boss = GetComponent<Boss1>();
        while(transform.position.x<player.position.x + 20f){
        transform.position = new Vector3(transform.position.x+ 15f * Time.deltaTime,  transform.position.y, transform.position.z);
        yield return null;

        }
    yield return new WaitForSeconds(1.5f);

        spriteRenderer.flipX = false;

        transform.position = new Vector3(player.position.x + 20f, player.position.y, transform.position.z);
        firerate=0;
        Sign();

    yield return new WaitForSeconds(1f);
    while(transform.position.x> player.position.x-20f){
        transform.position = new Vector3(transform.position.x- 30f * Time.deltaTime,  transform.position.y, transform.position.z);

    firerate += Time.deltaTime;
    minfire = 0.15f;
    Fire();
        yield return null;
    }
    yield return new WaitForSeconds(2f);
        transform.position = new Vector3(player.position.x - 20f, player.position.y, transform.position.z);
        firerate=0f;
        Sign();
        spriteRenderer.flipX = true;



    yield return new WaitForSeconds(1f);
        while(transform.position.x<player.position.x+20f){
        transform.position = new Vector3(transform.position.x+ 30f * Time.deltaTime,  transform.position.y, transform.position.z);
            firerate += Time.deltaTime;
            minfire = 0.12f;
        Fire();
        yield return null;

    }
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(player.position.x + 20f, player.position.y, transform.position.z);
        firerate=0f;
        Sign();
        spriteRenderer.flipX = false;


    yield return new WaitForSeconds(1f);
        while(transform.position.x>player.position.x-20f){
        transform.position = new Vector3(transform.position.x- 30f * Time.deltaTime,  transform.position.y, transform.position.z);
            firerate += Time.deltaTime;
            minfire = 0.09f;
            Fire();
        yield return null;

    }
    yield return new WaitForSeconds(2f);
        transform.position = new Vector3( player.position.x + 20f,  transform.position.y, transform.position.z);

        while(transform.position.x>player.position.x + 10f){
        transform.position = new Vector3(transform.position.x- 10f * Time.deltaTime,  transform.position.y, transform.position.z);
        yield return null;
    }
    boss.finish =true;


    }
    private void Sign(){
        Instantiate(
            sign,
            firePoint.position,
            firePoint.rotation
        );
    }
    private void Fire(){
        Boss1 boss = GetComponent<Boss1>();
    if (firerate >= minfire && boss.currentphase == 2)
    {
        ufireball.Execute();
        dfireball.Execute();

        firerate = 0f;
    }
    }
}
