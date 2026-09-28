using UnityEngine;

public class SBTrigger: MonoBehaviour
{
    [SerializeField] private StartBack startback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Trigger()
    {
        startback.start = true;
    }
}
