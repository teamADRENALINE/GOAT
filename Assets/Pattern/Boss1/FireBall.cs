using UnityEngine;
using System.Collections;

public class FireBall : Pattern
{
    [SerializeField] private Weapon hfireball;
    [SerializeField] private int maxfire = 10;
    [SerializeField] private Transform player;
    float speed = 0;
    int firecount = 0;
    int count = 0;
    int maxcount = 7;
    bool moving = false;

    public override void Execute()
    {
        StartCoroutine(Fire());
        moving = true;
        StartCoroutine(Move());

    }
    private IEnumerator Fire(){
        Boss1 boss = GetComponent<Boss1>();
    if(boss.currentphase == 1){
        count = maxcount;
    }
    else if(boss.currentphase == 2){
        count = maxcount*2;
    }
    while (count > 0){
    firecount = maxfire;
    while(firecount > 0){
        hfireball.Execute();
        firecount -=1;
        yield return null;
    }
    count -=1;
    
    if(boss.currentphase == 1){
    yield return new WaitForSeconds(0.4f);
    }
    else if(boss.currentphase == 2){
    yield return new WaitForSeconds(0.2f);
    }
    }

    yield return new WaitForSeconds(1.5f);
        moving =false;
        boss.finish = true;
        speed = 0f;
    }


    private IEnumerator Move(){
while (Mathf.Abs(transform.position.x - (player.position.x + 10f)) > 0.1f)
{
    float targetX = player.position.x + 10f;

    transform.position = new Vector3(
        Mathf.MoveTowards(
            transform.position.x,
            targetX,
            10f * Time.deltaTime
        ),
        transform.position.y,
        transform.position.z
    );

    yield return null;
}
    while (moving == true){
    if(transform.position.y < player.position.y){
    speed +=Time.deltaTime*30;
    transform.position = new Vector3(transform.position.x,  transform.position.y+ speed * Time.deltaTime, transform.position.z);
    }
    else{
        speed -=Time.deltaTime*30;
    transform.position = new Vector3(transform.position.x,  transform.position.y+ speed * Time.deltaTime, transform.position.z);
    }

    yield return null;

    }
}}