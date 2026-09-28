using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Damageable target;

    private void Update()
    {
        SetHP(target.CurrentHP, target.MaxHP);
    }

    public void SetHP(int currentHP, int maxHP)
    {
        slider.value = (float)currentHP / maxHP;
    }
}