using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public StartBack startback;
    [SerializeField] public StartBack go;

    [SerializeField] private GameObject gameover;
    [SerializeField] private Damageable damageableboss;
    public bool locked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Over(){
        locked = true;
        startback.start = true;
        go.start = true;
        StartCoroutine(Change());
    }
    private IEnumerator Change(){
        yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("BossSelect");
    }

}
