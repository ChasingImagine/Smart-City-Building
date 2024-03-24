using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour
{

    float best, now;

    [SerializeField] string sceneName;

    [SerializeField] float losdSceneTime;

    [SerializeField] GameObject loseManu;
    [SerializeField] TextMeshProUGUI LoseText;

    private Coroutine cor = null;
    public void Lose()
    {
        best = PlayerPrefs.GetFloat("Best",0);
        now = Gamaemenager.Isance.daye;


        if(best <now)
        {
            PlayerPrefs.SetFloat("Best", now);
            

        }

        PlayerPrefs.SetFloat("Now", now);
        if(cor == null) StartCoroutine(Looad());
    }


    IEnumerator Looad()
    {
        loseManu.SetActive(true);
        LoseText.text = "Sadece " + now + " gün dayanbildin";
        yield return new WaitForSeconds(losdSceneTime);
        SceneManager.LoadScene(sceneName);
    }


}
