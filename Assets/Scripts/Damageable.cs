using UnityEngine;
using System.Collections;
public class Damageable : MonoBehaviour
{
    [SerializeField] public int Maxhp = 10000;
    [SerializeField] public int Currenthp;
    [SerializeField] public float InvincibleTime = 1.5f;
    [SerializeField] public Killed killed;
    [SerializeField] public Graze graze;
    [SerializeField] public GameOver gameover;

    public bool hitting = false;
    public bool kill = false;
    private Phase phase;
    private SpriteRenderer spriteRenderer;

public int MaxHP => Maxhp;
public int CurrentHP => Currenthp;
    private void Start()
    {
        phase = GetComponent<Phase>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Currenthp = Maxhp;
        phase.StatUpdate();
    }

    public void TakeDamage(int damage)
    {
        if (CompareTag("Player") && hitting)
        {
            return;
        }
        Currenthp -= damage;
        Currenthp = Mathf.Max(Currenthp, 0);

        if (CompareTag("Player")){
            GameData.Misses += damage;
            graze.Currentgraze -= (int)(damage*0.1f);
            graze.Currentgraze = Mathf.Max(graze.Currentgraze, 0);
            StartCoroutine(NoDamage());
        if (Currenthp <= 0)
        {
            gameover.Over();
        }
        }

        if (CompareTag("Boss")){
            phase.StatUpdate();
        if (Currenthp <= 0 && kill == false && gameover.locked == false)
        {
            Die();
        }}
    }

    private void Die()
    {
        kill = true;
    }
    private IEnumerator NoDamage()
    {
        hitting = true;

        float time = 0f;

        while (time < InvincibleTime)
        {
            // 表示・非表示を切り替える
            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(0.1f);

            time += 0.1f;
        }

        // 最後は必ず表示
        spriteRenderer.enabled = true;

        hitting = false;
    }
}