using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private float maxtimer;

    float timer = 2f;

    private void Update()
    {

        if (timer > 0f)
        {
            timer -= Time.deltaTime;

        }
        else{
        currentWeapon.Execute();
        timer = maxtimer;
        }

    }
}