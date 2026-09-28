using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour
{
    [SerializeField] private GameObject fight;
    [SerializeField] private GameObject ready;

    public bool start = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ready.SetActive(true);
        fight.SetActive(false);
        StartCoroutine(Fight());

    }
    private IEnumerator Fight()
    {
    yield return new WaitForSeconds(2.5f);
        ready.SetActive(false);
        fight.SetActive(true);
        start =true;
    yield return new WaitForSeconds(1f);
        fight.SetActive(false);


    }
}
