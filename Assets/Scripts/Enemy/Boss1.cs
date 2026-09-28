using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField] private Ready ready;
    [SerializeField] private Damageable damageable;
    [SerializeField] public Killed killed;

    [SerializeField] private Phase phase;
    [SerializeField] private Pattern rush;
    [SerializeField] private int damage;
    public bool attacking = false;
    int currentphase = 0;
    private void Start(){
        attacking =false;
        currentphase = phase.CurrentPhase;
    }

    private void Update()
    {
    if(attacking == false && damageable.kill == true){
        stop();
        attacking = true;
    }
    else if(attacking == false && ready.start == true){
    int attack = Random.Range(1, 6);

    switch (attack)
    {
        case 1:
        if(currentphase == 1){
           rush.Execute();
           }
           break;

        case 2:
           //.Execute();
          break;

        case 3:
           //.Execute();
          break;
    }}

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
}