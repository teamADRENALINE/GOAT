using UnityEngine;
using System.Collections;

public class Infernum : Pattern
{
    [SerializeField] private GameObject flame;
    [SerializeField] private Player player;
    [SerializeField] private int damage=0;
    float speed=0f;
    int maxcount = 0;
    int rushcount = 0;
    float cooldown = 0f;
    float quater = 0f;

    private Vector3 PP;

    public override void Execute()
    {
        Boss1 boss = GetComponent<Boss1>();
        if(boss.currentphase == 1){
            maxcount = 16;
            rushcount = 3;
            cooldown = 1.5f;
            quater = 45f;
            speed = 5f;
        }
        else if(boss.currentphase == 2){
            maxcount = 32;
            rushcount = 5;
            cooldown = 0.75f;
            quater = 30f;
            speed = 8f;    
        }
        StartCoroutine(inf());
    }

    private IEnumerator inf()
    {
        Boss1 boss = GetComponent<Boss1>();

        for (int i = 1; i < (rushcount+1); i++)
        {
            // Playerの現在位置をPPに保存
            PP = player.transform.position;
            yield return new WaitForSeconds(cooldown);

            // PPの位置まで移動
while (Vector3.Distance(transform.position, PP) > 0.1f)
{
    Vector3 direction =
        (PP - transform.position).normalized;

    transform.position +=
        direction * 20f * Time.deltaTime;

    yield return null;
}

for (int p = 0; p < (maxcount+1); p++)
{
    float count = p * quater;

    GameObject obj = Instantiate(
        flame,
        transform.position,
        transform.rotation * Quaternion.Euler(0, 0, count)
    );

    EBullet bullet = obj.GetComponent<EBullet>();

    if (bullet != null)
    {
        bullet.damage = damage;
        bullet.speed = speed;
    }
    yield return new WaitForSeconds(0.03f);

}
        }
        boss.finish =true;

    }
}