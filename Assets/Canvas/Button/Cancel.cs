using UnityEngine;

public class Cancel : MonoBehaviour
{
    [SerializeField] private WeaponUI weaponui;

    public void Select()
    {
        weaponui.HideButton();
    }
}