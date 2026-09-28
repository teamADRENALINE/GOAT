using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class BTitle : MonoBehaviour
{
    public void ChangeScene()
    {
        StartCoroutine(Change());
    }
    private IEnumerator Change()
    {
    yield return new WaitForSeconds(0.7f);
            SceneManager.LoadScene("BossSelect");
    }
}
