using UnityEngine;

public class BPistol : MonoBehaviour
{
    [SerializeField] private BossSelect bossselect;
    int weapon=1;

    public void Select()
    {
        bossselect.SetWeapon(weapon);
    }
}