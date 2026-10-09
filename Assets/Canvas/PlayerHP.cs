using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private int currentValue = 0;
    [SerializeField] private int maxValue = 0;
    [SerializeField] private Damageable damageable;
    private void Update()
    {
        if(maxValue <= 0){
            StatUpdate();
        }
        float alpha = Mathf.Clamp01((float)currentValue / maxValue);
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
    public void StatUpdate(){
        maxValue = damageable.Maxhp;
        currentValue = damageable.Currenthp;
    }
}