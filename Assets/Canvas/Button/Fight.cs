using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fight : MonoBehaviour
{
    [SerializeField] private ChangeRL changerl;

    int maxboss = 3;
    int boss = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss = changerl.BossValue;
        maxboss = changerl.MaxBossValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeRL(){
        boss = changerl.BossValue;
        maxboss = changerl.MaxBossValue;
    }
    public void ChangeScene()
    {
        StartCoroutine(Change());
    }
    private IEnumerator Change()
    {
    yield return new WaitForSeconds(2.5f);
        if(boss == 1){
            SceneManager.LoadScene("Boss1");
        }
        else if(boss == 2){
            //SceneManager.LoadScene("Boss1");
        }
    }
}
