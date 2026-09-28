using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StellarStrike : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Graze target;
    [SerializeField] private TMP_Text grazeText;

    private void Update()
    {
        SetSS(target.CurrentGraze, target.MaxGraze);
    }

    public void SetSS(int currentGraze, int maxGraze)
    {
        // ゲージ
        slider.value = (float)currentGraze / maxGraze;

        // 数字
        grazeText.text = currentGraze + " / " + maxGraze;
    }
}