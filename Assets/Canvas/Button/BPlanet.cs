using UnityEngine;

public class BPilanet : MonoBehaviour
{
    [SerializeField] private BossSelect bossselect;
    int weapon=2;

    public void Select()
    {
        bossselect.SetWeapon(weapon);
    }
}