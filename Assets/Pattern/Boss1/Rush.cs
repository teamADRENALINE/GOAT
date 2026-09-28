using UnityEngine;
using System.Collections;
public class Rush : Pattern
{
    [SerializeField] private Weapon ufireball;
    [SerializeField] private Weapon dfireball;
    [SerializeField] private GameObject sign;
    [SerializeField] private Transform firePoint;

    [SerializeField] private Transform player;
    private float firerate=0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Execute()
    {
        Boss1 boss = GetComponent<Boss1>();

        transform.position = new Vector3(20f, player.position.y, transform.position.z);
        firerate=0;
        Sign();
        StartCoroutine(Attack());
        boss.attacking = true;
    }
    private IEnumerator Attack()
    {
    Boss1 boss = GetComponent<Boss1>();

    yield return new WaitForSeconds(1f);
    while(transform.position.x>-20f){
        transform.position = new Vector3(transform.position.x- 30f * Time.deltaTime,  transform.position.y, transform.position.z);

    firerate += Time.deltaTime;

    if (firerate >= 0.15f)
    {
        ufireball.Execute();
        dfireball.Execute();

        firerate = 0f;
    }
        yield return null;
    }
    yield return new WaitForSeconds(2f);
        transform.position = new Vector3(20f, player.position.y, transform.position.z);
        firerate=0f;
        Sign();


    yield return new WaitForSeconds(1f);
        while(transform.position.x>-20f){
        transform.position = new Vector3(transform.position.x- 30f * Time.deltaTime,  transform.position.y, transform.position.z);
            firerate += Time.deltaTime;

    if (firerate >= 0.12f)
    {
        ufireball.Execute();
        dfireball.Execute();

        firerate = 0f;
    }
        yield return null;

    }
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(20f, player.position.y, transform.position.z);
        firerate=0f;
        Sign();


    yield return new WaitForSeconds(1f);
        while(transform.position.x>-20f){
        transform.position = new Vector3(transform.position.x- 30f * Time.deltaTime,  transform.position.y, transform.position.z);
            firerate += Time.deltaTime;

    if (firerate >= 0.09f)
    {
        ufireball.Execute();
        dfireball.Execute();

        firerate = 0f;
    }
        yield return null;

    }
    yield return new WaitForSeconds(2f);
    transform.position = new Vector3(20f, 0f, 0f);

        while(transform.position.x>6f){
        transform.position = new Vector3(transform.position.x- 10f * Time.deltaTime,  transform.position.y, transform.position.z);
        yield return null;
    }
    transform.position = new Vector3(6f, 0f, 0f);
    boss.attacking =false;


    }
    private void Sign(){
        Instantiate(
            sign,
            firePoint.position,
            firePoint.rotation
        );
    }
}
