using UnityEngine;
using System.Collections;

public class Meteor : Pattern
{
    [SerializeField] private GameObject UPFire;
    [SerializeField] private GameObject DownFire;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform player;
    private Vector3 PP;

    bool UF = false;
    float count = 0f;
    float count2 = 0f;
    float scale = 1f;
    int maxfire = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Execute()
    {
        StartCoroutine(Fall());
    }
    private IEnumerator Fall(){
        Boss1 boss = GetComponent<Boss1>();

            // Playerの現在位置をPPに保存
            PP = player.transform.position;
            yield return new WaitForSeconds(1.5f);

            // PPの位置まで移動
while (Vector3.Distance(transform.position, PP) > 0.1f)
{
    Vector3 direction =
        (PP - transform.position).normalized;

    transform.position +=
        direction * 15f * Time.deltaTime;

    yield return null;
}
    UF = true;
    StartCoroutine(UpFire());
    yield return new WaitForSeconds(1f);

    for (int p = 0; p <= maxfire; p++){
        if(p >= (maxfire-10)){
            UF = false;
        }
    count = Random.Range(45f, 135f);
        float randomX = Random.Range(-4f, 4f);
    Vector3 spawnPosition = new Vector3(
        player.position.x + randomX,
        player.position.y + 7f,
        firePoint.position.z
            );
    GameObject obj = Instantiate(
        DownFire,
        spawnPosition,
        transform.rotation * Quaternion.Euler(0, 0, count)
    );
    scale = Random.Range(1f, 3f);

    obj.transform.localScale = DownFire.transform.localScale * scale;
    EBullet bullet = obj.GetComponent<EBullet>();

    if (bullet != null)
    {
        bullet.damage = 50+(int)(scale*50);
        bullet.speed = (7f-scale);
    }
        yield return new WaitForSeconds(0.3f);

    }
        yield return new WaitForSeconds(2f);
        UF = false;
        boss.finish =true;
    }


    private IEnumerator UpFire(){
        while(UF == true){
    count2 = Random.Range(-100f, -80f);

        GameObject obj2 = Instantiate(
            UPFire,
            transform.position,
            transform.rotation * Quaternion.Euler(0, 0, count2)
        );
    EBullet bullet = obj2.GetComponent<EBullet>();

    if (bullet != null)
    {
        bullet.damage = 50;
        bullet.speed = 12f;
    }
            yield return new WaitForSeconds(0.1f);
            yield return null;
        }
    }
}
