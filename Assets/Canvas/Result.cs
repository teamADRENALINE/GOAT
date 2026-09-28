using UnityEngine;
using System.Collections;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] private GameObject result;
    [SerializeField] private GameObject graze;
    [SerializeField] private GameObject miss;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject back;

    [SerializeField] private TMP_Text tgraze;
    [SerializeField] private TMP_Text tmiss;
    [SerializeField] private TMP_Text tscore;

    int maxscore = 0;
    int maxgraze = 0;
    int maxmiss = 0;
    bool cgraze = false;
    bool cmiss = false;
    bool cscore = false;
    int currentscore = 0;
    int currentgraze = 0;
    int currentmiss = 0;
    float grazeTime = 0f;
    float missTime = 0f;
    float scoreTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxgraze = GameData.Grazes;
        maxmiss = GameData.Misses;
        maxscore = 10000 + maxgraze*100 - maxmiss*50;
        result.SetActive(false);
        graze.SetActive(false);
        miss.SetActive(false);
        score.SetActive(false);
        back.SetActive(false);
        StartCoroutine(first());
    }

    // Update is called once per frame
    void Update()
    {
        if(cgraze == true){
            grazeTime += Time.deltaTime;

            currentgraze = Mathf.RoundToInt(
                Mathf.Lerp(0, maxgraze, grazeTime / 1f)
            );

            if (grazeTime >= 1f){
                currentgraze = maxgraze;
                cgraze = false;
                StartCoroutine(second());}
        tgraze.text = currentgraze.ToString()+"   Count";

            }
        
        if(cmiss == true){
            missTime += Time.deltaTime;

            currentmiss = Mathf.RoundToInt(
                Mathf.Lerp(0, maxmiss, missTime / 1f)
            );

            if (missTime >= 1f){
                currentmiss = maxmiss;
                cmiss = false;
                StartCoroutine(third());}
        tmiss.text = "- "+currentmiss.ToString()+"   HP";

            }
        
        if(cscore == true){
            scoreTime += Time.deltaTime;

            currentscore = Mathf.RoundToInt(
                Mathf.Lerp(0, maxscore, scoreTime / 1f)
            );

            if (scoreTime >= 1f){
                currentscore = maxscore;
                cscore = false;
                StartCoroutine(final());}
        tscore.text = currentscore.ToString();

            }
        }
    
    private IEnumerator first()
    {
    yield return new WaitForSeconds(1f);
    result.SetActive(true);
    yield return new WaitForSeconds(1.5f);
    graze.SetActive(true);
    yield return new WaitForSeconds(1f);
    cgraze = true;
    grazeTime = 0f;

    }
    private IEnumerator second()
    {
    yield return new WaitForSeconds(1.5f);
    miss.SetActive(true);
    yield return new WaitForSeconds(1f);
    cmiss = true;
    missTime = 0f;

    }
    private IEnumerator third()
    {
    yield return new WaitForSeconds(1.5f);
    score.SetActive(true);
    yield return new WaitForSeconds(1f);
    cscore = true;
    scoreTime = 0f;
    }
    private IEnumerator final()
    {
    yield return new WaitForSeconds(1f);
    back.SetActive(true);
    }
}
