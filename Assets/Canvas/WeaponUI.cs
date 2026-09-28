using UnityEngine;

public class WeaponUI : MonoBehaviour
{
[SerializeField] private GameObject pistol;
[SerializeField] private GameObject planet;
[SerializeField] private GameObject cancel;
[SerializeField] private GameObject weapon;
void Start(){
    HideButton();
}
    public void ShowButton()
{
    pistol.SetActive(true);
    planet.SetActive(true);
    cancel.SetActive(true);
    weapon.SetActive(false);

}

public void HideButton()
{
    pistol.SetActive(false);
    planet.SetActive(false);
    cancel.SetActive(false);
    weapon.SetActive(true);
}
}