using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ScorTableUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nowText;
    [SerializeField] TextMeshProUGUI bestText;



    private void Start()
    {
        nowText.text = (PlayerPrefs.GetFloat("Now",0f) == 0 ? "Son Oynda daynýlan gün syýsý : -" : ("Son Oynda daynýlan Gün : " + (int)PlayerPrefs.GetFloat("Now")));
        bestText.text = (PlayerPrefs.GetFloat("Best", 0f) == 0 ? " Daynýlan eniyi günsyýsý : -" : (" Daynýlan eniyi günsyýsý : "  + (int)PlayerPrefs.GetFloat("Now")));
    }
}
