using UnityEngine;

public class BossSelect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeapon(int weapon)
    {
        GameData.WeaponID = weapon;
    }
}
