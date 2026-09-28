using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BBack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        StartCoroutine(Change());
    }
    private IEnumerator Change()
    {
    yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("BossSelect");
    }
}
