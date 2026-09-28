using UnityEngine;
using UnityEngine.UI;

public class ChangeRL : MonoBehaviour
{
    [SerializeField] private int MaxBoss = 0;
    [SerializeField] private Fight fight;

    [SerializeField] private GameObject bright;
    [SerializeField] private GameObject bleft;
    [SerializeField] private int Boss = 1;

    [SerializeField] private Image image;
    [SerializeField] private Sprite image1;
    [SerializeField] private Sprite image2;
    [SerializeField] private Sprite image3;

    public int BossValue => Boss;
    public int MaxBossValue => MaxBoss;
    bool selecting = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if(selecting == true){
            if(Boss == MaxBoss){
                bright.SetActive(false);
            }
            else if (Boss == 1){
                bleft.SetActive(false);
            }
            else{
                bright.SetActive(true);
                bleft.SetActive(true); 
            }
            selecting =false;
        }
    }
    public void BRight(){
        if(Boss < MaxBoss){
            Boss += 1;
            Change();
            selecting = true;
            fight.ChangeRL();
        }
    }
    public void BLeft(){
        if(Boss > 1){
            Boss -= 1;
            Change();
            selecting = true;
            fight.ChangeRL();
        }
    }
    public void Change(){
switch (Boss)
{
    case 1:
        image.sprite = image1;
        break;

    case 2:
        image.sprite = image2;
        break;

    case 3:
        image.sprite = image3;
        break;

    default:
        break;
}
    }
}
