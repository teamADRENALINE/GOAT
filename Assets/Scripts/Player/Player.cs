using UnityEngine;

public class Player : MonoBehaviour
{
[SerializeField] private Weapon currentWeapon;

[SerializeField] private Weapon pistol;
[SerializeField] private Weapon planet;
[SerializeField] private Ready ready;
[SerializeField] public GameOver gameover;

private void Start()
{
    if (GameData.WeaponID == 1)
    {
        currentWeapon = pistol;
    }
    else if (GameData.WeaponID == 2)
    {
        currentWeapon = planet;
    }
}

private void Update()
{
    if (ready.start == true && gameover.locked == false)
    {
        if (currentWeapon is Planet planetWeapon)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentWeapon.Execute();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                planetWeapon.Release();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentWeapon.Execute();
            }
        }
    }
}

}
