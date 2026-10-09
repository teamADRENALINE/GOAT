using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour
{
    [SerializeField] private Ready ready;
    [SerializeField] private Damageable damageable;
    [SerializeField] public Killed killed;
    [SerializeField] private Transform player;
    [SerializeField] private Phase phase;
    [SerializeField] private Pattern rush;
    [SerializeField] private Pattern fireball;
    [SerializeField] private Pattern circle;
    [SerializeField] private Pattern setexpo;
    [SerializeField] private Pattern infernum;
    [SerializeField] private Pattern meteor;

    [SerializeField] private int damage;
    public bool attacking = false;//攻撃中
    public bool finish = false;//攻撃終了合図
    public bool moving = false;//待機中
    public bool killing = false;//死亡合図

    int maxrandom = 7;

    public int currentphase = 0;
    int oldphase = 0;
    float rantime = 0f;
    int attack = 0;
[SerializeField] private float speed = 0f;
[SerializeField] private float maxSpeed = 10f;
[SerializeField] private float acceleration = 30f;

    private void Start(){
        attacking =false;
        currentphase = phase.CurrentPhase;
    }

    private void Update()
    {
    if((moving == true || finish == true) && damageable.kill == true && killing == false){
        stop();
        moving = false;
        killing = true;
    }
    else if(finish == true && killing == false){
        finish = false;
        speed = 0f;
        StartCoroutine(del());
        StartCoroutine(Move());
    }
    else if(attacking == false && ready.start == true){
        currentphase = phase.CurrentPhase;
    switch (currentphase){
        case 1:
            maxrandom = 3;
        break;
        case 2:
            maxrandom = 5;
        break;
        case 3:
            maxrandom = 1;
        break;
    }
    if (maxrandom != 1){
    attack = Random.Range(1, maxrandom+1);
    while(attack == oldphase){
        attack = Random.Range(1, maxrandom+1);
    }}
    else{
        attack = 1;
    }

    //attack = 6;
    attacking =true;
    if(currentphase == 1){
    switch (attack)
    {
        case 1:
           rush.Execute();
           break;
        case 2:
           fireball.Execute();
           break;
        case 3:
           infernum.Execute();
           break;
    }}
    else if(currentphase == 2){
    switch (attack)
    {
        case 1:
           rush.Execute();
           break;
        case 2:
           fireball.Execute();
           break;
        case 3:
           infernum.Execute();
           break;
        case 4:
           setexpo.Execute();
           break;
        case 5:
           circle.Execute();
           break;
    }
    }
    else if(currentphase == 3){
    switch (attack)
    {
        case 1:
           meteor.Execute();
           break;
    }


    }
        oldphase = attack;
    }

    }
        private void OnTriggerEnter2D(Collider2D other){
    Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null && other.CompareTag("Player"))
    {
        damageable.TakeDamage(damage);
    }
    }
    private void stop(){
        killed.kill();
    }
    private IEnumerator del(){
        rantime = Random.Range(5f, 10f);
        yield return new WaitForSeconds(rantime);
        moving = false;
        finish = false;
        attacking = false;
    }

private IEnumerator Move()
{
    moving = true;

    while (moving == true)
    {
        // =========================
        // X移動
        // =========================

        float targetX = player.position.x + 10f;
        float distanceX = Mathf.Abs(targetX - transform.position.x);

        // 距離が遠いほど速くする
        float moveSpeed = Mathf.Clamp(distanceX * 5f, 2f, 15f);

        transform.position = new Vector3(
            Mathf.MoveTowards(
                transform.position.x,
                targetX,
                moveSpeed * Time.deltaTime
            ),
            transform.position.y,
            transform.position.z
        );


        // =========================
        // Y移動
        // =========================

        if (transform.position.y < player.position.y)
        {
            speed += Time.deltaTime * acceleration;
        }
        else
        {
            speed -= Time.deltaTime * acceleration;
        }

        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + speed * Time.deltaTime,
            transform.position.z
        );

        yield return null;
    }
}
}