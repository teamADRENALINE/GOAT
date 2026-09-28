using UnityEngine;

public class Phase : MonoBehaviour
{
    [SerializeField] public int MaxPhase = 1;
    [SerializeField] public int CurrentPhase = 1;
    [SerializeField] private float ChangePhase1 = 0.8f;
    [SerializeField] private float ChangePhase2 = 0.6f;
    [SerializeField] private float ChangePhase3 = 0.4f;
    [SerializeField] private float ChangePhase4 = 0.2f;
    [SerializeField] private float ChangePhase5 = 0.1f;
    float ChangePhasehp=0f;
    [SerializeField] private int Maxhp =0;
    [SerializeField] private int Currenthp =0;
    private Damageable damageable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damageable = GetComponent<Damageable>();
        SetPhase();
    }

    // Update is called once per frame

    void PhaseChange(){
        if(CurrentPhase == 1){
            ChangePhasehp = Maxhp*ChangePhase1;
        }
        else if (CurrentPhase == 2){
            ChangePhasehp = Maxhp*ChangePhase2;
        }
        else if (CurrentPhase == 3){
            ChangePhasehp = Maxhp*ChangePhase3;
        }
        else if (CurrentPhase == 4){
            ChangePhasehp = Maxhp*ChangePhase4;
        }
        else if (CurrentPhase == 5){
            ChangePhasehp = Maxhp*ChangePhase5;
        }
    }
    void SetPhase(){
        if(ChangePhase2 == 0){
            MaxPhase = 1;
        }
        else if(ChangePhase3 == 0){
            MaxPhase = 2;
        }
        else if(ChangePhase4 == 0){
            MaxPhase = 3;
        }
        else if(ChangePhase5 == 0){
            MaxPhase = 4;
        }
        else{
            MaxPhase = 5;
        }
    }
    public void StatUpdate(){
       Maxhp = damageable.Maxhp;
       Currenthp = damageable.Currenthp;
    }
}
